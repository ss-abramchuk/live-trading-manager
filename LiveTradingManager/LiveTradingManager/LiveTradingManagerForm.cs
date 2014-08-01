using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using WealthLab;
using Fidelity.Components;

using WLDSolutions.LiveTradingManager.Abstract;
using WLDSolutions.LiveTradingManager.Helpers;
using WLDSolutions.LiveTradingManager.Settings;

namespace WLDSolutions.LiveTradingManager
{
    internal partial class LiveTradingManagerForm : Form
    {
        private List<LTProductDescription> _ltProducts;

        private ILTSettingsProvider _ltSettings;

        public LiveTradingManagerForm(ILTSettingsProvider ltSettings)
        {
            _ltSettings = ltSettings;

            FillProducts();

            InitializeComponent();

            cbSettingToSelect.SelectedIndex = 0;

            cbProductName.DataSource = _ltProducts;
            cbProductName.DisplayMember = "ProductName";
        }

        private void FillProducts()
        {
            _ltProducts = new List<LTProductDescription>();

            AssemblyLoader assemblyLoader = new AssemblyLoader();
            assemblyLoader.BaseClass = "LTProductDescription";

            assemblyLoader.Path = Path.GetDirectoryName(Application.ExecutablePath);

            foreach (Type type in assemblyLoader.Types)
            {
                LTProductDescription assemblyDescription = (LTProductDescription)assemblyLoader.CreateInstance(type);
                _ltProducts.Add(assemblyDescription);
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            LTProductDescription currProductDescription = (LTProductDescription)cbProductName.SelectedItem;

            settingsPanel.Controls.Clear();

            LTSettingsPanel currSettingsPanel = currProductDescription.SettingsPanel;

            if (currSettingsPanel != null)
                settingsPanel.Controls.Add(currSettingsPanel);
            else
                settingsPanel.Controls.Add(new DummyNoSettings());            
        }

        private void GoToSetting(object sender, EventArgs e)
        {
            switch (cbSettingToSelect.SelectedIndex)
            {                
                case (0):
                    LiveTradingTimeZones rttTimeZones = new LiveTradingTimeZones(_ltSettings);

                    rttTimeZones.MdiParent = GetParentForm();

                    rttTimeZones.Show();
                    rttTimeZones.Activate();

                    break;
            }
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
