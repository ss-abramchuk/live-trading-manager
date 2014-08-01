using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WealthLab;

namespace WLDSolutions.LiveTradingManager.Abstract
{
    public class LTAccount : Account
    {
        public virtual string ProviderName
        {
            get;
            set;
        }
    }
}
