using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WLDSolutions.LiveTradingManager.Abstract;
using WLDSolutions.LiveTradingManager.Settings;

namespace WLDSolutions.LiveTradingManager.Dispatcher
{
    public class LTDispatcher
    {
        #region Свойства диспетчера

        public ILTSettingsProvider LTSettingsProvider
        {
            get;
            private set;
        }

        #endregion

        #region Singleton

        private static readonly LTDispatcher _instance = new LTDispatcher();

        public static LTDispatcher Instance
        {
            get { return _instance; }
        }

        static LTDispatcher()
        {

        }

        private LTDispatcher()
        {
            string dataPath = string.Concat(Application.UserAppDataPath, "\\Data");

            LTSettingsProvider = new LiveTradingSettingsProvider(dataPath, "\\LTManager.xml");
        }

        #endregion
    }
}
