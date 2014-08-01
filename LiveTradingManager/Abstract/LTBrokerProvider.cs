using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WealthLab;

using WLDSolutions.LiveTradingManager.Helpers;

namespace WLDSolutions.LiveTradingManager.Abstract
{
    public abstract class LTBrokerProvider
    {
        public abstract void Initialize();

        #region Работа с аккаунтами

        public abstract event Action<LTAccount> AccountUpdate;

        public abstract List<LTAccount> GetAccounts();

        public abstract void UpdateAccounts();

        public abstract List<string> AccountTradeTypes(string account);

        #endregion

        #region Работа с ордерами

        public abstract event Action<OrderUpdateInfo> OrderUpdate;

        public abstract List<Order> Orders
        {
            get;
            set;
        }

        public abstract void PlaceOrder(Order order);

        public abstract void CancelOrder(Order order);

        public abstract void OrderStatusUpdate(Order order);

        public abstract bool AllowOrderType(OrderType orderType);

        public abstract List<string> TifsAllowed();

        #endregion

        #region Настройки брокер адаптера

        public abstract string ProviderName
        {
            get;
        }

        public abstract bool Enable
        {
            get;
        }

        #endregion
    }
}
