namespace Курсовая.NET_Framework__WinForms_
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAdminIndicator = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.узлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.атсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.телефоныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорииВыходаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операторОтчётовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учетныеЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModifySubscriber = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFreedExtension = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1133, 472);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 494);
            this.panel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelRowCount,
            this.toolStripStatusLabelAdminIndicator});
            this.statusStrip1.Location = new System.Drawing.Point(0, 472);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1133, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRowCount
            // 
            this.toolStripStatusLabelRowCount.Name = "toolStripStatusLabelRowCount";
            this.toolStripStatusLabelRowCount.Size = new System.Drawing.Size(123, 17);
            this.toolStripStatusLabelRowCount.Text = "Строк отображено: 0";
            // 
            // toolStripStatusLabelAdminIndicator
            // 
            this.toolStripStatusLabelAdminIndicator.BackColor = System.Drawing.Color.Aquamarine;
            this.toolStripStatusLabelAdminIndicator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelAdminIndicator.Enabled = false;
            this.toolStripStatusLabelAdminIndicator.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabelAdminIndicator.ForeColor = System.Drawing.SystemColors.MenuText;
            this.toolStripStatusLabelAdminIndicator.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelAdminIndicator.Name = "toolStripStatusLabelAdminIndicator";
            this.toolStripStatusLabelAdminIndicator.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabelAdminIndicator.Text = "[Admin]";
            this.toolStripStatusLabelAdminIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabelAdminIndicator.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.справочникToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1133, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "&Меню";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("выходToolStripMenuItem.Image")));
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.выходToolStripMenuItem.Text = "&Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.узлыToolStripMenuItem,
            this.атсToolStripMenuItem,
            this.телефоныToolStripMenuItem,
            this.категорииВыходаToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "&Справочник";
            // 
            // узлыToolStripMenuItem
            // 
            this.узлыToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("узлыToolStripMenuItem.Image")));
            this.узлыToolStripMenuItem.Name = "узлыToolStripMenuItem";
            this.узлыToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.узлыToolStripMenuItem.Text = "&ЖД узлы";
            this.узлыToolStripMenuItem.Click += new System.EventHandler(this.узлыToolStripMenuItem_Click);
            // 
            // атсToolStripMenuItem
            // 
            this.атсToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("атсToolStripMenuItem.Image")));
            this.атсToolStripMenuItem.Name = "атсToolStripMenuItem";
            this.атсToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.атсToolStripMenuItem.Text = "&АТС";
            this.атсToolStripMenuItem.Click += new System.EventHandler(this.атсToolStripMenuItem_Click);
            // 
            // телефоныToolStripMenuItem
            // 
            this.телефоныToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("телефоныToolStripMenuItem.Image")));
            this.телефоныToolStripMenuItem.Name = "телефоныToolStripMenuItem";
            this.телефоныToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.телефоныToolStripMenuItem.Text = "&Телефоны";
            this.телефоныToolStripMenuItem.Click += new System.EventHandler(this.телефоныToolStripMenuItem_Click);
            // 
            // категорииВыходаToolStripMenuItem
            // 
            this.категорииВыходаToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("категорииВыходаToolStripMenuItem.Image")));
            this.категорииВыходаToolStripMenuItem.Name = "категорииВыходаToolStripMenuItem";
            this.категорииВыходаToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.категорииВыходаToolStripMenuItem.Text = "&Категории выхода";
            this.категорииВыходаToolStripMenuItem.Click += new System.EventHandler(this.категорииВыходаToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операторОтчётовToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "&Отчёты";
            // 
            // операторОтчётовToolStripMenuItem
            // 
            this.операторОтчётовToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("операторОтчётовToolStripMenuItem.Image")));
            this.операторОтчётовToolStripMenuItem.Name = "операторОтчётовToolStripMenuItem";
            this.операторОтчётовToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.операторОтчётовToolStripMenuItem.Text = "О&ператор отчётов";
            this.операторОтчётовToolStripMenuItem.Click += new System.EventHandler(this.операторОтчётовToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учетныеЗаписиToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "&Настройки";
            this.настройкиToolStripMenuItem.Visible = false;
            // 
            // учетныеЗаписиToolStripMenuItem
            // 
            this.учетныеЗаписиToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("учетныеЗаписиToolStripMenuItem.Image")));
            this.учетныеЗаписиToolStripMenuItem.Name = "учетныеЗаписиToolStripMenuItem";
            this.учетныеЗаписиToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.учетныеЗаписиToolStripMenuItem.Text = "&Учетные записи";
            this.учетныеЗаписиToolStripMenuItem.Click += new System.EventHandler(this.учетныеЗаписиToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1133, 29);
            this.panel2.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripButtonHistory,
            this.toolStripButtonModifySubscriber,
            this.toolStripButtonFreedExtension});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1133, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonRefresh.Text = "toolStripButton1";
            this.toolStripButtonRefresh.ToolTipText = "Обновить";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripButtonHistory
            // 
            this.toolStripButtonHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHistory.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHistory.Image")));
            this.toolStripButtonHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHistory.Name = "toolStripButtonHistory";
            this.toolStripButtonHistory.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonHistory.Text = "toolStripButton2";
            this.toolStripButtonHistory.ToolTipText = "Показать историю изменений";
            this.toolStripButtonHistory.Click += new System.EventHandler(this.toolStripButtonHistory_Click);
            // 
            // toolStripButtonModifySubscriber
            // 
            this.toolStripButtonModifySubscriber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonModifySubscriber.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonModifySubscriber.Image")));
            this.toolStripButtonModifySubscriber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonModifySubscriber.Name = "toolStripButtonModifySubscriber";
            this.toolStripButtonModifySubscriber.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonModifySubscriber.Text = "toolStripButton3";
            this.toolStripButtonModifySubscriber.ToolTipText = "Внести изменения в выбранный объект";
            this.toolStripButtonModifySubscriber.Click += new System.EventHandler(this.toolStripButtonModifySubscriber_Click);
            // 
            // toolStripButtonFreedExtension
            // 
            this.toolStripButtonFreedExtension.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFreedExtension.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFreedExtension.Image")));
            this.toolStripButtonFreedExtension.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFreedExtension.Name = "toolStripButtonFreedExtension";
            this.toolStripButtonFreedExtension.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonFreedExtension.Text = "toolStripButton4";
            this.toolStripButtonFreedExtension.ToolTipText = "Перевести телефон в статус \"Свободен\"";
            this.toolStripButtonFreedExtension.Click += new System.EventHandler(this.toolStripButtonFreedExtension_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 547);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Система хранения данных о телефонах";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRowCount;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonHistory;
        private System.Windows.Forms.ToolStripButton toolStripButtonModifySubscriber;
        private System.Windows.Forms.ToolStripButton toolStripButtonFreedExtension;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAdminIndicator;
        private System.Windows.Forms.ToolStripMenuItem операторОтчётовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem телефоныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорииВыходаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem узлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem атсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учетныеЗаписиToolStripMenuItem;
    }
}

