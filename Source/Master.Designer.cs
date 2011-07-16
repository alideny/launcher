namespace eXLauncher
{
    partial class Master
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
            this.chosenRealm = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chosenRealm
            // 
            this.chosenRealm.FormattingEnabled = true;
            this.chosenRealm.Location = new System.Drawing.Point(540, 452);
            this.chosenRealm.Name = "chosenRealm";
            this.chosenRealm.Size = new System.Drawing.Size(121, 21);
            this.chosenRealm.TabIndex = 0;
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 528);
            this.Controls.Add(this.chosenRealm);
            this.Name = "Master";
            this.Text = "eXLauncher";
            this.Load += new System.EventHandler(this.Master_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox chosenRealm;
    }
}

