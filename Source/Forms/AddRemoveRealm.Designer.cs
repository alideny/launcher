namespace launcher
{
    partial class AddRemoveRealm
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
            this.addrealm = new System.Windows.Forms.RadioButton();
            this.removerealm = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addrealm_panel = new System.Windows.Forms.Panel();
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.realmlist_textbox = new System.Windows.Forms.TextBox();
            this.clientversion = new System.Windows.Forms.ComboBox();
            this.addremovebutton = new System.Windows.Forms.Button();
            this.addrealm_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addrealm
            // 
            this.addrealm.Appearance = System.Windows.Forms.Appearance.Button;
            this.addrealm.AutoSize = true;
            this.addrealm.BackColor = System.Drawing.Color.Transparent;
            this.addrealm.Checked = true;
            this.addrealm.ForeColor = System.Drawing.Color.White;
            this.addrealm.Location = new System.Drawing.Point(229, 35);
            this.addrealm.Name = "addrealm";
            this.addrealm.Size = new System.Drawing.Size(87, 27);
            this.addrealm.TabIndex = 0;
            this.addrealm.TabStop = true;
            this.addrealm.Text = "Add Realm";
            this.addrealm.UseVisualStyleBackColor = false;
            // 
            // removerealm
            // 
            this.removerealm.Appearance = System.Windows.Forms.Appearance.Button;
            this.removerealm.AutoSize = true;
            this.removerealm.ForeColor = System.Drawing.Color.White;
            this.removerealm.Location = new System.Drawing.Point(322, 35);
            this.removerealm.Name = "removerealm";
            this.removerealm.Size = new System.Drawing.Size(114, 27);
            this.removerealm.TabIndex = 1;
            this.removerealm.Text = "Remove Realm";
            this.removerealm.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Realmlist:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-3, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Client Version:";
            // 
            // addrealm_panel
            // 
            this.addrealm_panel.BackColor = System.Drawing.Color.Transparent;
            this.addrealm_panel.Controls.Add(this.clientversion);
            this.addrealm_panel.Controls.Add(this.realmlist_textbox);
            this.addrealm_panel.Controls.Add(this.name_textbox);
            this.addrealm_panel.Controls.Add(this.label3);
            this.addrealm_panel.Controls.Add(this.label1);
            this.addrealm_panel.Controls.Add(this.label2);
            this.addrealm_panel.Location = new System.Drawing.Point(195, 86);
            this.addrealm_panel.Name = "addrealm_panel";
            this.addrealm_panel.Size = new System.Drawing.Size(267, 148);
            this.addrealm_panel.TabIndex = 5;
            // 
            // name_textbox
            // 
            this.name_textbox.Location = new System.Drawing.Point(110, 13);
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(145, 22);
            this.name_textbox.TabIndex = 5;
            // 
            // realmlist_textbox
            // 
            this.realmlist_textbox.Location = new System.Drawing.Point(110, 42);
            this.realmlist_textbox.Name = "realmlist_textbox";
            this.realmlist_textbox.Size = new System.Drawing.Size(145, 22);
            this.realmlist_textbox.TabIndex = 6;
            // 
            // clientversion
            // 
            this.clientversion.FormattingEnabled = true;
            this.clientversion.Items.AddRange(Config.PrintClientVersions());
            this.clientversion.Location = new System.Drawing.Point(110, 70);
            this.clientversion.Name = "clientversion";
            this.clientversion.Size = new System.Drawing.Size(145, 24);
            this.clientversion.TabIndex = 7;
            // 
            // addremovebutton
            // 
            this.addremovebutton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addremovebutton.ForeColor = System.Drawing.Color.White;
            this.addremovebutton.Location = new System.Drawing.Point(322, 277);
            this.addremovebutton.Name = "addremovebutton";
            this.addremovebutton.Size = new System.Drawing.Size(114, 32);
            this.addremovebutton.TabIndex = 6;
            this.addremovebutton.Text = "Add Realm";
            this.addremovebutton.UseVisualStyleBackColor = false;
            this.addremovebutton.Click += new System.EventHandler(this.addremovebutton_Click);
            // 
            // AddRemoveRealm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::launcher.Properties.Resources.messagebox;
            this.ClientSize = new System.Drawing.Size(474, 321);
            this.Controls.Add(this.addremovebutton);
            this.Controls.Add(this.addrealm_panel);
            this.Controls.Add(this.removerealm);
            this.Controls.Add(this.addrealm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddRemoveRealm";
            this.Text = "Add/Remove a Realm";
            this.addrealm_panel.ResumeLayout(false);
            this.addrealm_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton addrealm;
        private System.Windows.Forms.RadioButton removerealm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel addrealm_panel;
        private System.Windows.Forms.ComboBox clientversion;
        private System.Windows.Forms.TextBox realmlist_textbox;
        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.Button addremovebutton;
    }
}