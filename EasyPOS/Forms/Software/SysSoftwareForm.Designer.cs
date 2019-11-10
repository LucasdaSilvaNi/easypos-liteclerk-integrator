namespace EasyPOS.Forms.Software
{
    partial class SysSoftwareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysSoftwareForm));
            this.tabControlSoftware = new System.Windows.Forms.TabControl();
            this.tabPageSysMenu = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxLastChange = new System.Windows.Forms.TextBox();
            this.labelLastChange = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelCurrentUser = new System.Windows.Forms.Label();
            this.tabControlSoftware.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSoftware
            // 
            this.tabControlSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSoftware.Controls.Add(this.tabPageSysMenu);
            this.tabControlSoftware.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControlSoftware.Location = new System.Drawing.Point(0, 40);
            this.tabControlSoftware.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlSoftware.Name = "tabControlSoftware";
            this.tabControlSoftware.Padding = new System.Drawing.Point(0, 0);
            this.tabControlSoftware.SelectedIndex = 0;
            this.tabControlSoftware.Size = new System.Drawing.Size(1408, 733);
            this.tabControlSoftware.TabIndex = 0;
            this.tabControlSoftware.SelectedIndexChanged += new System.EventHandler(this.tabControlSoftware_SelectedIndexChanged);
            // 
            // tabPageSysMenu
            // 
            this.tabPageSysMenu.BackColor = System.Drawing.Color.White;
            this.tabPageSysMenu.Location = new System.Drawing.Point(4, 29);
            this.tabPageSysMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSysMenu.Name = "tabPageSysMenu";
            this.tabPageSysMenu.Size = new System.Drawing.Size(1400, 700);
            this.tabPageSysMenu.TabIndex = 0;
            this.tabPageSysMenu.Text = "Menu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.panel1.Controls.Add(this.textBoxLastChange);
            this.panel1.Controls.Add(this.labelLastChange);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 776);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1408, 121);
            this.panel1.TabIndex = 9;
            // 
            // textBoxLastChange
            // 
            this.textBoxLastChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLastChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.textBoxLastChange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLastChange.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.textBoxLastChange.ForeColor = System.Drawing.Color.White;
            this.textBoxLastChange.Location = new System.Drawing.Point(958, 48);
            this.textBoxLastChange.Name = "textBoxLastChange";
            this.textBoxLastChange.ReadOnly = true;
            this.textBoxLastChange.Size = new System.Drawing.Size(371, 34);
            this.textBoxLastChange.TabIndex = 9;
            this.textBoxLastChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxLastChange.Visible = false;
            // 
            // labelLastChange
            // 
            this.labelLastChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLastChange.AutoSize = true;
            this.labelLastChange.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelLastChange.ForeColor = System.Drawing.Color.White;
            this.labelLastChange.Location = new System.Drawing.Point(1084, 13);
            this.labelLastChange.Name = "labelLastChange";
            this.labelLastChange.Size = new System.Drawing.Size(124, 25);
            this.labelLastChange.TabIndex = 8;
            this.labelLastChange.Text = "Last Change:";
            this.labelLastChange.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Easy POS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(151, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Version: 1.20191109";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(151, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Support: (032) 234 0787";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(151, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Developer: Easyfis Corporation";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.labelCurrentUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1408, 37);
            this.panel2.TabIndex = 10;
            // 
            // labelCurrentUser
            // 
            this.labelCurrentUser.AutoSize = true;
            this.labelCurrentUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelCurrentUser.Location = new System.Drawing.Point(12, 10);
            this.labelCurrentUser.Name = "labelCurrentUser";
            this.labelCurrentUser.Size = new System.Drawing.Size(0, 20);
            this.labelCurrentUser.TabIndex = 0;
            // 
            // SysSoftwareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1408, 897);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlSoftware);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SysSoftwareForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Easy POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SysSoftwareForm_FormClosing);
            this.tabControlSoftware.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSoftware;
        private System.Windows.Forms.TabPage tabPageSysMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelLastChange;
        private System.Windows.Forms.TextBox textBoxLastChange;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelCurrentUser;
    }
}