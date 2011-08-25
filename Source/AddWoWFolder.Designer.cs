namespace eXLauncher
{
    partial class AddWoWFolder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.locale = new System.Windows.Forms.TextBox();
            this.client = new System.Windows.Forms.TextBox();
            this.box_location = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(116, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Locale:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(116, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "WoW.exe File:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(116, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Client Version:";
            // 
            // locale
            // 
            this.locale.Location = new System.Drawing.Point(237, 37);
            this.locale.Name = "locale";
            this.locale.Size = new System.Drawing.Size(163, 22);
            this.locale.TabIndex = 3;
            // 
            // client
            // 
            this.client.Location = new System.Drawing.Point(237, 77);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(163, 22);
            this.client.TabIndex = 4;
            // 
            // box_location
            // 
            this.box_location.Location = new System.Drawing.Point(237, 119);
            this.box_location.Name = "box_location";
            this.box_location.Size = new System.Drawing.Size(189, 22);
            this.box_location.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addbutton
            // 
            this.addbutton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addbutton.ForeColor = System.Drawing.Color.White;
            this.addbutton.Location = new System.Drawing.Point(332, 247);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(128, 32);
            this.addbutton.TabIndex = 7;
            this.addbutton.Text = "Add WoW Folder";
            this.addbutton.UseVisualStyleBackColor = false;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // AddWoWFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::eXLauncher.Properties.Resources.messagebox;
            this.ClientSize = new System.Drawing.Size(472, 320);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.box_location);
            this.Controls.Add(this.client);
            this.Controls.Add(this.locale);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddWoWFolder";
            this.Text = "Add WoW Folder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox locale;
        private System.Windows.Forms.TextBox client;
        private System.Windows.Forms.TextBox box_location;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addbutton;
    }
}