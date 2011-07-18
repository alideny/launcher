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
            this.chosenRealm = new System.Windows.Forms.ListBox();
            this.btnStartWoW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chosenRealm
            // 
            this.chosenRealm.FormattingEnabled = true;
            this.chosenRealm.Location = new System.Drawing.Point(12, 47);
            this.chosenRealm.Name = "chosenRealm";
            this.chosenRealm.Size = new System.Drawing.Size(153, 355);
            this.chosenRealm.TabIndex = 0;
            // 
            // btnStartWoW
            // 
            this.btnStartWoW.Location = new System.Drawing.Point(624, 459);
            this.btnStartWoW.Name = "btnStartWoW";
            this.btnStartWoW.Size = new System.Drawing.Size(75, 23);
            this.btnStartWoW.TabIndex = 1;
            this.btnStartWoW.Text = "button1";
            this.btnStartWoW.UseVisualStyleBackColor = true;
            this.btnStartWoW.Click += new System.EventHandler(this.btnStartWoW_Click);
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 528);
            this.Controls.Add(this.btnStartWoW);
            this.Controls.Add(this.chosenRealm);
            this.Name = "Master";
            this.Text = "eXLauncher";
            this.Load += new System.EventHandler(this.Master_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox chosenRealm;
        private System.Windows.Forms.Button btnStartWoW;

    }
}

