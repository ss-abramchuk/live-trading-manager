using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WLDSolutions.LiveTradingManager.Helpers
{
    [System.Reflection.ObfuscationAttribute(Feature = "renaming", ApplyToMembers = true)]
    internal sealed class TimeZoneName
    {
        public string DisplayName
        {
            get;
            private set;
        }

        public string StandartName
        {
            get;
            private set;
        }

        public TimeZoneName(string displayName, string standartName)
        {
            DisplayName = displayName;
            StandartName = standartName;
        }
    }
}
