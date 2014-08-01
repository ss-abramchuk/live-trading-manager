using System;
using System.Windows.Forms;
using System.Text;

using WealthLab;

using WLDSolutions.LiveTradingManager.Settings;
using WLDSolutions.LiveTradingManager.Dispatcher;

namespace WLDSolutions.LiveTradingManager
{
    public sealed class LiveTradingManagerInit : MenuItemHook
    {
        private LiveTradingManagerForm _ltManagerForm;
        
        public override void AddMenuItems(IMenuItemAdder adder)
        {
            adder.AddMenuItem("Live Trading Manager", "&Tools", "&Accounts", new ClickMenuItem(this.ClickMenuEvent), Properties.Resources.iconRTTpng);
        }

        private void ClickMenuEvent(Object obj, EventArgs eventArgs)
        {
            if (_ltManagerForm == null || _ltManagerForm.IsDisposed)
            {
                Application.DoEvents();

                _ltManagerForm = new LiveTradingManagerForm(LTDispatcher.Instance.LTSettingsProvider);

                _ltManagerForm.MdiParent = GetParentForm();
            }

            _ltManagerForm.Show();
            _ltManagerForm.Activate();
        }

        private Form GetParentForm()
        {
            Form result = null;

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "MainForm")
                    result = form;
            }

            return result;
        }
    }    
}
