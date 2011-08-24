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
            this.btnStartWoW = new System.Windows.Forms.Button();
            this.chosenRealm = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnStartWoW
            // 
            this.btnStartWoW.Location = new System.Drawing.Point(832, 565);
            this.btnStartWoW.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartWoW.Name = "btnStartWoW";
            this.btnStartWoW.Size = new System.Drawing.Size(100, 28);
            this.btnStartWoW.TabIndex = 1;
            this.btnStartWoW.Text = "button1";
            this.btnStartWoW.UseVisualStyleBackColor = true;
            this.btnStartWoW.Click += new System.EventHandler(this.btnStartWoW_Click);
            // 
            // chosenRealm
            // 
            this.chosenRealm.BackgroundImage = global::eXLauncher.Properties.Resources.Launcherv2;
            this.chosenRealm.BackgroundImageTiled = true;
            this.chosenRealm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chosenRealm.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chosenRealm.ForeColor = System.Drawing.Color.White;
            this.chosenRealm.Location = new System.Drawing.Point(29, 45);
            this.chosenRealm.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.chosenRealm.Name = "chosenRealm";
            this.chosenRealm.Size = new System.Drawing.Size(127, 566);
            this.chosenRealm.TabIndex = 2;
            this.chosenRealm.UseCompatibleStateImageBehavior = false;
            this.chosenRealm.View = System.Windows.Forms.View.List;
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::eXLauncher.Properties.Resources.Launcherv3;
            this.ClientSize = new System.Drawing.Size(802, 641);
            this.Controls.Add(this.chosenRealm);
            this.Controls.Add(this.btnStartWoW);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Master";
            this.Text = "Launcher";
            this.Load += new System.EventHandler(this.Master_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartWoW;
        private System.Windows.Forms.ListView chosenRealm;

    }
}

