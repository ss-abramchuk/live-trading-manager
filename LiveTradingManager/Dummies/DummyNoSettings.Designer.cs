namespace WLDSolutions.LiveTradingManager
{
    partial class DummyNoSettings
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
            this.lblNoSettings = new System.Windows.Forms.Label();
            this.gbNoSettings = new System.Windows.Forms.GroupBox();
            this.gbNoSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNoSettings
            // 
            this.lblNoSettings.AutoSize = true;
            this.lblNoSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNoSettings.Location = new System.Drawing.Point(16, 22);
            this.lblNoSettings.Name = "lblNoSettings";
            this.lblNoSettings.Size = new System.Drawing.Size(371, 20);
            this.lblNoSettings.TabIndex = 0;
            this.lblNoSettings.Text = "Для данного продукта нет доступных настроек";
            // 
            // gbNoSettings
            // 
            this.gbNoSettings.Controls.Add(this.lblNoSettings);
            this.gbNoSettings.Location = new System.Drawing.Point(3, 48);
            this.gbNoSettings.Name = "gbNoSettings";
            this.gbNoSettings.Size = new System.Drawing.Size(405, 59);
            this.gbNoSettings.TabIndex = 1;
            this.gbNoSettings.TabStop = false;
            // 
            // DummyNoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbNoSettings);
            this.Name = "DummyNoSettings";
            this.gbNoSettings.ResumeLayout(false);
            this.gbNoSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNoSettings;
        private System.Windows.Forms.GroupBox gbNoSettings;
    }
}
