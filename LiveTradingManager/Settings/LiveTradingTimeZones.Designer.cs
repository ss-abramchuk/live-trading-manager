namespace WLDSolutions.LiveTradingManager.Settings
{
    partial class LiveTradingTimeZones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvTimeZones = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bsTimeZoneNames = new System.Windows.Forms.BindingSource(this.components);
            this.bsMarketManagerTimeZones = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeZones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTimeZoneNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarketManagerTimeZones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimeZones
            // 
            this.dgvTimeZones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeZones.Location = new System.Drawing.Point(12, 12);
            this.dgvTimeZones.Name = "dgvTimeZones";
            this.dgvTimeZones.RowHeadersVisible = false;
            this.dgvTimeZones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTimeZones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTimeZones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimeZones.Size = new System.Drawing.Size(522, 217);
            this.dgvTimeZones.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(378, 235);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Применить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(459, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RTTTimeZones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 264);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvTimeZones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RTTTimeZones";
            this.Text = "Настройка часовых поясов для Market Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeZones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTimeZoneNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarketManagerTimeZones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimeZones;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource bsTimeZoneNames;
        private System.Windows.Forms.BindingSource bsMarketManagerTimeZones;
    }
}