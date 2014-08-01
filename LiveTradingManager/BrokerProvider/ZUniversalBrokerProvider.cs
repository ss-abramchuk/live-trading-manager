using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

using WealthLab;
using Fidelity.Components;
using log4net;

using WLDSolutions.LiveTradingManager.Abstract;
using WLDSolutions.LiveTradingManager.Helpers;


namespace WLDSolutions.LiveTradingManager.BrokerProvider
{
    [ProductionBrokerProvider]
    public sealed class ZUniversalBrokerProvider : WealthLab.BrokerProvider
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ZUniversalBrokerProvider));

        private List<LTBrokerProvider> _providers;
        private List<LTAccount> _accounts;
        private List<string> _routes;

        private object _orderUpdateLocker = new object();
        private object _accountUpdateLocker = new object();

        public ZUniversalBrokerProvider()
        {
            _providers = new List<LTBrokerProvider>();
            _accounts = new List<LTAccount>();
            _routes = new List<string>();
        }

        public override void Initialize(IBrokerHost brokerHost, AuthenticationProvider authProvider)
        {
            base.Initialize(brokerHost, authProvider);
            authProvider.AllowAutoTrading = true;

            AssemblyLoader assemblyLoader = new AssemblyLoader();
            assemblyLoader.BaseClass = "LTBrokerProvider";

            assemblyLoader.Path = Path.GetDirectoryName(Application.ExecutablePath);

            foreach (Type type in assemblyLoader.Types)
            {
                try
                {
                    LTBrokerProvider assemblyDescription = (LTBrokerProvider)assemblyLoader.CreateInstance(type);

                    assemblyDescription.Initialize();

                    if (assemblyDescription.Enable)
                    {
                        assemblyDescription.AccountUpdate += AccountUpdate;
                        assemblyDescription.OrderUpdate += OrderStatusUpdate;

                        _providers.Add(assemblyDescription);
                        _routes.Add(assemblyDescription.ProviderName);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);

                    if (ex.InnerException != null)
                        _logger.Error(ex.InnerException);
                }
            }
        }

        #region Обновление информации о статусе ордеров и об открытых позициях

        private void OrderStatusUpdate(OrderUpdateInfo updateInfo)
        {
            lock (_orderUpdateLocker)
                base.BrokerHost.OrderStatusUpdate(updateInfo.OrderID, updateInfo.OrderStatus, updateInfo.TimeStamp, updateInfo.FillPrice, updateInfo.FillQty, updateInfo.Code, updateInfo.Message);
        }

        private void AccountUpdate(Account account)
        {
            lock (_accountUpdateLocker)
            {
                base.BrokerHost.AccountPositionsUpdate(account);
                base.BrokerHost.AccountBalanceUpdate(account);
            }
        }

        public override void RequestOrderStatusUpdates(Account acct)
        {
            if (acct == null)
            {
                foreach (LTBrokerProvider provider in _providers)
                {
                    List<LTAccount> accounts = _accounts.FindAll(x => x.ProviderName == provider.ProviderName);

                    foreach (Account account in accounts)
                    {
                        provider.Orders.AddRange(base.BrokerHost.GetOrders(account));
                    }

                    foreach (Order order in provider.Orders)
                        provider.OrderStatusUpdate(order);
                }
            }
            else
            {
                LTBrokerProvider ltProvider = (from account in _accounts
                                                 from provider in _providers
                                                 where account.AccountNumber == acct.AccountNumber &&
                                                 account.ProviderName == provider.ProviderName
                                                 select provider).FirstOrDefault();

                if (ltProvider != null)
                {
                    List<Order> orders = base.BrokerHost.GetOrders(acct);

                    foreach (Order order in orders)
                    {
                        ltProvider.OrderStatusUpdate(order);
                    }
                }
            }
        }

        public override void RequestOrderStatusUpdatesForOrders(IList<Order> orders)
        {
            foreach (Order order in orders)
            {
                LTBrokerProvider ltProvider = (from provider in _providers
                                                 from account in _accounts
                                                 where order.Account == account.AccountNumber &&
                                                 account.ProviderName == provider.ProviderName
                                                 select provider).FirstOrDefault();

                if (ltProvider != null)
                    ltProvider.OrderStatusUpdate(order);
            }
        }

        protected override List<Account> GetAccounts()
        {
            _accounts.Clear();

            foreach (LTBrokerProvider provider in _providers)
            {
                _accounts.AddRange(provider.GetAccounts());
            }

            List<Account> wlAccounts = new List<Account>();
            wlAccounts.AddRange(_accounts);

            return wlAccounts;
        }

        public override void UpdateAccounts()
        {
            foreach (LTBrokerProvider provider in _providers)
            {
                provider.UpdateAccounts();
            }
        }

        #endregion

        #region Отправка/отмена ордеров

        public override void PlaceOrder(IList<Order> orders)
        {
            foreach (Order order in orders)
                PlaceOrder(order);
        }

        public override void PlaceOrder(Order order)
        {
            LTBrokerProvider ltProvider = (from provider in _providers
                                             from account in _accounts
                                             where order.Account == account.AccountNumber &&
                                             account.ProviderName == provider.ProviderName
                                             select provider).FirstOrDefault();

            if (ltProvider != null)
                ltProvider.PlaceOrder(order);
        }

        public override void CancelOrder(IList<Order> orders)
        {
            foreach (Order order in orders)
                CancelOrder(order);
        }

        public override void CancelOrder(Order order)
        {
            LTBrokerProvider ltProvider = (from provider in _providers
                                             from account in _accounts
                                             where order.Account == account.AccountNumber &&
                                             account.ProviderName == provider.ProviderName
                                             select provider).FirstOrDefault();

            if (ltProvider != null)
                ltProvider.CancelOrder(order);
        }

        public override void CancelReplace(Order order, Order newOrder)
        {
            throw new NotImplementedException();
        }

        public override bool AllowCancelReplace(Order order, string bracketConditional)
        {
            return false;
        }

        #endregion

        #region Служебная информация

        public override string RouteForStrategyOrders(BarDataScale scale)
        {
            return "UniversalBrokerAdapter";
        }

        public override string TifForStrategyOrders(BarDataScale scale)
        {
            return "Default";
        }

        public override IList<string> RoutesForAccountNumber(string acctNumber)
        {
            string routes = (from account in _accounts
                            from provider in _providers
                            where account.AccountNumber == acctNumber &&
                            account.ProviderName == provider.ProviderName
                            select provider.ProviderName).DefaultIfEmpty("Default").First();


            return new List<string>() { routes };
        }

        public override List<string> TifsAllowed(string acctNumber, string route, string orderType)
        {
            LTBrokerProvider ltProvider = (from account in _accounts
                                             from provider in _providers
                                             where account.AccountNumber == acctNumber &&
                                             account.ProviderName == provider.ProviderName
                                             select provider).FirstOrDefault();

            if (ltProvider != null)
                return ltProvider.TifsAllowed();
            else
                return new List<string>();

        }

        public override IList<string> Routes
        {
            get { return _routes; }
        }

        public override List<string> AccountTradeTypesAllowed(string acctNumber, string action)
        {
            LTBrokerProvider ltProvider = (from account in _accounts
                                             from provider in _providers
                                             where account.AccountNumber == acctNumber &&
                                             account.ProviderName == provider.ProviderName
                                             select provider).FirstOrDefault();

            if (ltProvider != null)
                return ltProvider.AccountTradeTypes(acctNumber);
            else
                return new List<string>() { "Default" };
        }

        public override List<string> ExtendedOrderTypesAllowed(string acctNum, string route, string action)
        {
            return new List<string>();
        }

        public override bool AllowOrderTypeForRoute(string route, OrderType orderType)
        {
            LTBrokerProvider ltProvider = (from provider in _providers
                                             where provider.ProviderName == route
                                             select provider).FirstOrDefault();

            if (ltProvider != null)
                return ltProvider.AllowOrderType(orderType);
            else
                return true;
        }

        #endregion
    }
}
