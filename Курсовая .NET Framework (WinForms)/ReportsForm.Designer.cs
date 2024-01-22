namespace Курсовая.NET_Framework__WinForms_
{
    partial class ReportsForm
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
            this.linkLabelReportAllUsedExtensionsExcel = new System.Windows.Forms.LinkLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.linkLabelReportAllUsedExtensionsHtm = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // linkLabelReportAllUsedExtensionsExcel
            // 
            this.linkLabelReportAllUsedExtensionsExcel.AutoSize = true;
            this.linkLabelReportAllUsedExtensionsExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabelReportAllUsedExtensionsExcel.Location = new System.Drawing.Point(0, 0);
            this.linkLabelReportAllUsedExtensionsExcel.Name = "linkLabelReportAllUsedExtensionsExcel";
            this.linkLabelReportAllUsedExtensionsExcel.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.linkLabelReportAllUsedExtensionsExcel.Size = new System.Drawing.Size(224, 23);
            this.linkLabelReportAllUsedExtensionsExcel.TabIndex = 0;
            this.linkLabelReportAllUsedExtensionsExcel.TabStop = true;
            this.linkLabelReportAllUsedExtensionsExcel.Text = "Список телефонов в эксплуатации (Excel)";
            this.linkLabelReportAllUsedExtensionsExcel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelReportAllUsedExtensionsExcel_LinkClicked);
            // 
            // linkLabelReportAllUsedExtensionsHtm
            // 
            this.linkLabelReportAllUsedExtensionsHtm.AutoSize = true;
            this.linkLabelReportAllUsedExtensionsHtm.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabelReportAllUsedExtensionsHtm.Location = new System.Drawing.Point(0, 23);
            this.linkLabelReportAllUsedExtensionsHtm.Name = "linkLabelReportAllUsedExtensionsHtm";
            this.linkLabelReportAllUsedExtensionsHtm.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.linkLabelReportAllUsedExtensionsHtm.Size = new System.Drawing.Size(218, 23);
            this.linkLabelReportAllUsedExtensionsHtm.TabIndex = 1;
            this.linkLabelReportAllUsedExtensionsHtm.TabStop = true;
            this.linkLabelReportAllUsedExtensionsHtm.Text = "Список телефонов в эксплуатации (.htm)";
            this.linkLabelReportAllUsedExtensionsHtm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelReportAllUsedExtensionsHtm_LinkClicked);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 450);
            this.Controls.Add(this.linkLabelReportAllUsedExtensionsHtm);
            this.Controls.Add(this.linkLabelReportAllUsedExtensionsExcel);
            this.Name = "ReportsForm";
            this.ShowIcon = false;
            this.Text = "Отчёты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelReportAllUsedExtensionsExcel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.LinkLabel linkLabelReportAllUsedExtensionsHtm;
    }
}