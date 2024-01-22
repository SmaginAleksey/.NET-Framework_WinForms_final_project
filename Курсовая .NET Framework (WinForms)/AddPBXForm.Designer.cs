namespace Курсовая.NET_Framework__WinForms_
{
    partial class AddPBXForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxRailroadStation = new System.Windows.Forms.TextBox();
            this.textBoxPBXModel = new System.Windows.Forms.TextBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.panelTopRight = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelTopLeft.SuspendLayout();
            this.panelTopRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(0, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(97, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "АТС";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(97, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "ЖД узел";
            // 
            // textBoxRailroadStation
            // 
            this.textBoxRailroadStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRailroadStation.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxRailroadStation.Location = new System.Drawing.Point(0, 0);
            this.textBoxRailroadStation.Name = "textBoxRailroadStation";
            this.textBoxRailroadStation.Size = new System.Drawing.Size(220, 20);
            this.textBoxRailroadStation.TabIndex = 2;
            // 
            // textBoxPBXModel
            // 
            this.textBoxPBXModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPBXModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxPBXModel.Location = new System.Drawing.Point(0, 20);
            this.textBoxPBXModel.Name = "textBoxPBXModel";
            this.textBoxPBXModel.Size = new System.Drawing.Size(220, 20);
            this.textBoxPBXModel.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelTopRight);
            this.panelTop.Controls.Add(this.panelTopLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(317, 41);
            this.panelTop.TabIndex = 4;
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.Controls.Add(this.textBox1);
            this.panelTopLeft.Controls.Add(this.textBox2);
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(97, 41);
            this.panelTopLeft.TabIndex = 0;
            // 
            // panelTopRight
            // 
            this.panelTopRight.Controls.Add(this.textBoxPBXModel);
            this.panelTopRight.Controls.Add(this.textBoxRailroadStation);
            this.panelTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopRight.Location = new System.Drawing.Point(97, 0);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(220, 41);
            this.panelTopRight.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(122, 75);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // AddPBXForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 110);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.panelTop);
            this.Name = "AddPBXForm";
            this.ShowIcon = false;
            this.Text = "Добавить новую АТС";
            this.panelTop.ResumeLayout(false);
            this.panelTopLeft.ResumeLayout(false);
            this.panelTopLeft.PerformLayout();
            this.panelTopRight.ResumeLayout(false);
            this.panelTopRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxRailroadStation;
        private System.Windows.Forms.TextBox textBoxPBXModel;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelTopRight;
        private System.Windows.Forms.Panel panelTopLeft;
        private System.Windows.Forms.Button buttonAdd;
    }
}