namespace WLDSolutions.LiveTradingManager
{
    partial class LiveTradingManagerForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbProductName = new System.Windows.Forms.ComboBox();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.gbNoProductsInstalled = new System.Windows.Forms.GroupBox();
            this.lblNoProductsInstalled = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.btnGoToSetting = new System.Windows.Forms.Button();
            this.cbSettingToSelect = new System.Windows.Forms.ComboBox();
            this.gbAddInsSettings = new System.Windows.Forms.GroupBox();
            this.settingsPanel.SuspendLayout();
            this.gbNoProductsInstalled.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbAddInsSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbProductName
            // 
            this.cbProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductName.FormattingEnabled = true;
            this.cbProductName.Location = new System.Drawing.Point(9, 20);
            this.cbProductName.Name = "cbProductName";
            this.cbProductName.Size = new System.Drawing.Size(411, 21);
            this.cbProductName.TabIndex = 1;
            this.cbProductName.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.gbNoProductsInstalled);
            this.settingsPanel.Location = new System.Drawing.Point(9, 48);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(411, 180);
            this.settingsPanel.TabIndex = 2;
            // 
            // gbNoProductsInstalled
            // 
            this.gbNoProductsInstalled.Controls.Add(this.lblNoProductsInstalled);
            this.gbNoProductsInstalled.Location = new System.Drawing.Point(4, -2);
            this.gbNoProductsInstalled.Name = "gbNoProductsInstalled";
            this.gbNoProductsInstalled.Size = new System.Drawing.Size(403, 178);
            this.gbNoProductsInstalled.TabIndex = 1;
            this.gbNoProductsInstalled.TabStop = false;
            // 
            // lblNoProductsInstalled
            // 
            this.lblNoProductsInstalled.AutoSize = true;
            this.lblNoProductsInstalled.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNoProductsInstalled.Location = new System.Drawing.Point(43, 75);
            this.lblNoProductsInstalled.Name = "lblNoProductsInstalled";
            this.lblNoProductsInstalled.Size = new System.Drawing.Size(317, 25);
            this.lblNoProductsInstalled.TabIndex = 0;
            this.lblNoProductsInstalled.Text = "Нет установленных продуктов";
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.btnGoToSetting);
            this.gbSettings.Controls.Add(this.cbSettingToSelect);
            this.gbSettings.Location = new System.Drawing.Point(12, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(429, 54);
            this.gbSettings.TabIndex = 7;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Общие настройки";
            // 
            // btnGoToSetting
            // 
            this.btnGoToSetting.Location = new System.Drawing.Point(345, 19);
            this.btnGoToSetting.Name = "btnGoToSetting";
            this.btnGoToSetting.Size = new System.Drawing.Size(75, 23);
            this.btnGoToSetting.TabIndex = 1;
            this.btnGoToSetting.Text = "Перейти...";
            this.btnGoToSetting.UseVisualStyleBackColor = true;
            this.btnGoToSetting.Click += new System.EventHandler(this.GoToSetting);
            // 
            // cbSettingToSelect
            // 
            this.cbSettingToSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSettingToSelect.FormattingEnabled = true;
            this.cbSettingToSelect.Items.AddRange(new object[] {
            "Настройки часовых поясов для Market Manager"});
            this.cbSettingToSelect.Location = new System.Drawing.Point(9, 20);
            this.cbSettingToSelect.Name = "cbSettingToSelect";
            this.cbSettingToSelect.Size = new System.Drawing.Size(330, 21);
            this.cbSettingToSelect.TabIndex = 0;
            // 
            // gbAddInsSettings
            // 
            this.gbAddInsSettings.Controls.Add(this.cbProductName);
            this.gbAddInsSettings.Controls.Add(this.settingsPanel);
            this.gbAddInsSettings.Location = new System.Drawing.Point(12, 72);
            this.gbAddInsSettings.Name = "gbAddInsSettings";
            this.gbAddInsSettings.Size = new System.Drawing.Size(429, 238);
            this.gbAddInsSettings.TabIndex = 8;
            this.gbAddInsSettings.TabStop = false;
            this.gbAddInsSettings.Text = "Настройки продуктов";
            // 
            // LiveTradingManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 323);
            this.Controls.Add(this.gbAddInsSettings);
            this.Controls.Add(this.gbSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LiveTradingManagerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Live Trading Manager";
            this.settingsPanel.ResumeLayout(false);
            this.gbNoProductsInstalled.ResumeLayout(false);
            this.gbNoProductsInstalled.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbAddInsSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProductName;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Label lblNoProductsInstalled;
        private System.Windows.Forms.GroupBox gbNoProductsInstalled;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Button btnGoToSetting;
        private System.Windows.Forms.ComboBox cbSettingToSelect;
        private System.Windows.Forms.GroupBox gbAddInsSettings;
    }
}