using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WealthLab;

namespace WLDSolutions.LiveTradingManager.Helpers
{
    public class OrderUpdateInfo
    {
        public string OrderID
        {
            get;
            set;
        }

        public OrderStatus OrderStatus
        {
            get;
            set;
        }

        public DateTime TimeStamp
        {
            get;
            set;
        }

        public double FillPrice
        {
            get;
            set;
        }

        public double FillQty
        {
            get;
            set;
        }

        public int Code
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}
