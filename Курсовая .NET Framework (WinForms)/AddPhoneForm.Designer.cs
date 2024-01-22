namespace Курсовая.NET_Framework__WinForms_
{
    partial class AddPhoneForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopRight = new System.Windows.Forms.Panel();
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxVendor = new System.Windows.Forms.TextBox();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelTopRight.SuspendLayout();
            this.panelTopLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelTopRight);
            this.panelTop.Controls.Add(this.panelTopLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(317, 62);
            this.panelTop.TabIndex = 0;
            // 
            // panelTopRight
            // 
            this.panelTopRight.Controls.Add(this.comboBoxTypes);
            this.panelTopRight.Controls.Add(this.textBoxModel);
            this.panelTopRight.Controls.Add(this.textBoxVendor);
            this.panelTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopRight.Location = new System.Drawing.Point(118, 0);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(199, 62);
            this.panelTopRight.TabIndex = 1;
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTypes.FormattingEnabled = true;
            this.comboBoxTypes.Location = new System.Drawing.Point(0, 40);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(199, 21);
            this.comboBoxTypes.TabIndex = 2;
            // 
            // textBoxModel
            // 
            this.textBoxModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxModel.Location = new System.Drawing.Point(0, 20);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(199, 20);
            this.textBoxModel.TabIndex = 1;
            // 
            // textBoxVendor
            // 
            this.textBoxVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxVendor.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxVendor.Location = new System.Drawing.Point(0, 0);
            this.textBoxVendor.Name = "textBoxVendor";
            this.textBoxVendor.Size = new System.Drawing.Size(199, 20);
            this.textBoxVendor.TabIndex = 0;
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.Controls.Add(this.textBox3);
            this.panelTopLeft.Controls.Add(this.textBox2);
            this.panelTopLeft.Controls.Add(this.textBox1);
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(118, 62);
            this.panelTopLeft.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(0, 40);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(118, 21);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Тип";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(0, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(118, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Модель";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(118, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Производитель";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(122, 75);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // AddPhoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 110);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddPhoneForm";
            this.Text = "Добавить новый телефон";
            this.panelTop.ResumeLayout(false);
            this.panelTopRight.ResumeLayout(false);
            this.panelTopRight.PerformLayout();
            this.panelTopLeft.ResumeLayout(false);
            this.panelTopLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelTopRight;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.TextBox textBoxVendor;
        private System.Windows.Forms.Panel panelTopLeft;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxTypes;
        private System.Windows.Forms.Button buttonAdd;
    }
}