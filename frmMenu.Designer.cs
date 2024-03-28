namespace CaroGame
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGuide = new System.Windows.Forms.Button();
            this.btnPvE = new System.Windows.Forms.Button();
            this.btnPvP = new System.Windows.Forms.Button();
            this.pnlIcon = new System.Windows.Forms.Panel();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.btnExit);
            this.pnlOptions.Controls.Add(this.btnGuide);
            this.pnlOptions.Controls.Add(this.btnPvE);
            this.pnlOptions.Controls.Add(this.btnPvP);
            this.pnlOptions.Location = new System.Drawing.Point(389, 13);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(234, 369);
            this.pnlOptions.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(23, 286);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(191, 61);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGuide
            // 
            this.btnGuide.Location = new System.Drawing.Point(23, 198);
            this.btnGuide.Name = "btnGuide";
            this.btnGuide.Size = new System.Drawing.Size(191, 61);
            this.btnGuide.TabIndex = 1;
            this.btnGuide.TabStop = false;
            this.btnGuide.Text = "Hướng dẫn";
            this.btnGuide.UseVisualStyleBackColor = true;
            this.btnGuide.Click += new System.EventHandler(this.btnGuide_Click);
            // 
            // btnPvE
            // 
            this.btnPvE.Location = new System.Drawing.Point(23, 110);
            this.btnPvE.Name = "btnPvE";
            this.btnPvE.Size = new System.Drawing.Size(191, 61);
            this.btnPvE.TabIndex = 1;
            this.btnPvE.TabStop = false;
            this.btnPvE.Text = "Chơi với máy";
            this.btnPvE.UseVisualStyleBackColor = true;
            this.btnPvE.Click += new System.EventHandler(this.btnPvE_Click);
            // 
            // btnPvP
            // 
            this.btnPvP.Location = new System.Drawing.Point(23, 22);
            this.btnPvP.Name = "btnPvP";
            this.btnPvP.Size = new System.Drawing.Size(191, 61);
            this.btnPvP.TabIndex = 1;
            this.btnPvP.TabStop = false;
            this.btnPvP.Text = "Chơi 2 người";
            this.btnPvP.UseVisualStyleBackColor = true;
            this.btnPvP.Click += new System.EventHandler(this.btnPvP_Click);
            // 
            // pnlIcon
            // 
            this.pnlIcon.BackgroundImage = global::CaroGame.Properties.Resources.Caro;
            this.pnlIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlIcon.Location = new System.Drawing.Point(12, 12);
            this.pnlIcon.Name = "pnlIcon";
            this.pnlIcon.Size = new System.Drawing.Size(370, 370);
            this.pnlIcon.TabIndex = 0;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 389);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro";
            this.pnlOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIcon;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Button btnPvP;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGuide;
        private System.Windows.Forms.Button btnPvE;
    }
}