using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WLDSolutions.LiveTradingManager.Helpers;

namespace WLDSolutions.LiveTradingManager.Abstract
{
    public abstract class LTProductDescription
    {
        public abstract string ProductName
        {
            get;
        }

        public abstract string Version
        {
            get;
        }

        public abstract LTSettingsPanel SettingsPanel
        {
            get;
        }

        public abstract bool NeedActivation
        {
            get;
        }
    }
}
