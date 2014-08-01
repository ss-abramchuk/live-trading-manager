using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WLDSolutions.LiveTradingManager.Helpers;

namespace WLDSolutions.LiveTradingManager.Abstract
{
    public class LTSettingsPanel : UserControl
    {
        public virtual string HardwareKey
        {
            get;
            set;
        }

        public LTSettingsPanel()
            : base()
        {
            base.Location = new System.Drawing.Point(0, 0);
            base.Size = new System.Drawing.Size(411, 180);
        }
    }
}
