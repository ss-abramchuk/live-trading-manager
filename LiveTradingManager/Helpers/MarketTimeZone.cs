using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WLDSolutions.LiveTradingManager.Helpers
{
    public class MarketTimeZone
    {
        public string MarketName
        {
            get;
            set;
        }

        public string TimeZoneName
        {
            get;
            set;
        }

        public MarketTimeZone()
        {
            MarketName = string.Empty;
            TimeZoneName = string.Empty;
        }

        public MarketTimeZone(string marketName, string timeZoneName)
        {
            MarketName = marketName;
            TimeZoneName = timeZoneName;
        }
    }
}
