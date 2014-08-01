using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;

using Fidelity.Components;

using WLDSolutions.LiveTradingManager.Abstract;
using WLDSolutions.LiveTradingManager.Helpers;

namespace WLDSolutions.LiveTradingManager.Settings
{
    internal partial class LiveTradingTimeZones : Form
    {
        private ILTSettingsProvider _settingsProvider;

        private List<TimeZoneName> _timeZoneNames;
        private List<MarketTimeZone> _marketTimeZones;

        public LiveTradingTimeZones(ILTSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;

            InitializeComponent();

            dgvTimeZones.AutoGenerateColumns = false;

            FillTimeZones();
            bsTimeZoneNames.DataSource = _timeZoneNames;

            _marketTimeZones = new List<MarketTimeZone>();
            FillDataGrid();
        }

        private void FillTimeZones()
        {
            _timeZoneNames = new List<TimeZoneName>();

            foreach (TimeZoneInformation timeZoneInfo in TimeZoneInformation.TimeZones)
            {
                _timeZoneNames.Add(new TimeZoneName(timeZoneInfo.DisplayName, timeZoneInfo.Name));
            }

            _timeZoneNames.Sort((x, y) => x.DisplayName.CompareTo(y.DisplayName));
        }

        private void FillDataGrid()
        {
            _marketTimeZones.Clear();

            object buffer = _settingsProvider.GetObject("MarketTimeZones", typeof(List<MarketTimeZone>));

            if (buffer != null)
                _marketTimeZones.AddRange((List<MarketTimeZone>)buffer);

            bsMarketManagerTimeZones.DataSource = _marketTimeZones;

            dgvTimeZones.DataSource = bsMarketManagerTimeZones;

            DataGridViewTextBoxColumn marketCode = new DataGridViewTextBoxColumn();
            marketCode.HeaderText = "Код рынка";
            marketCode.Width = 120;
            marketCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            marketCode.DataPropertyName = "MarketName";

            DataGridViewComboBoxColumn timeZone = new DataGridViewComboBoxColumn();
            timeZone.HeaderText = "Часовой пояс";
            timeZone.Width = 180;
            timeZone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            timeZone.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            timeZone.DataSource = bsTimeZoneNames;
            timeZone.DataPropertyName = "TimeZoneName";
            timeZone.DisplayMember = "DisplayName";
            timeZone.ValueMember = "StandartName";

            dgvTimeZones.Columns.Add(marketCode);
            dgvTimeZones.Columns.Add(timeZone);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvTimeZones.Columns.Clear();

            FillDataGrid();

            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _settingsProvider.SaveObject("MarketTimeZones", _marketTimeZones);

            this.Close();
        }
    }
}
