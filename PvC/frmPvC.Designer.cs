namespace CaroGame.PvC
{
    partial class frmPvC
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
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.btnBackMenu = new System.Windows.Forms.Button();
            this.btnStartPvE = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblGuide = new System.Windows.Forms.Label();
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.pnlPicture = new System.Windows.Forms.Panel();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.Ivory;
            this.pnlStatus.Controls.Add(this.btnBackMenu);
            this.pnlStatus.Controls.Add(this.btnStartPvE);
            this.pnlStatus.Controls.Add(this.btnBack);
            this.pnlStatus.Controls.Add(this.lblGuide);
            this.pnlStatus.Location = new System.Drawing.Point(11, 361);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(345, 355);
            this.pnlStatus.TabIndex = 3;
            // 
            // btnBackMenu
            // 
            this.btnBackMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackMenu.Location = new System.Drawing.Point(23, 135);
            this.btnBackMenu.Name = "btnBackMenu";
            this.btnBackMenu.Size = new System.Drawing.Size(303, 85);
            this.btnBackMenu.TabIndex = 4;
            this.btnBackMenu.TabStop = false;
            this.btnBackMenu.Text = "Back to menu";
            this.btnBackMenu.UseVisualStyleBackColor = true;
            this.btnBackMenu.Click += new System.EventHandler(this.btnBackMenu_Click);
            // 
            // btnStartPvE
            // 
            this.btnStartPvE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPvE.Location = new System.Drawing.Point(23, 25);
            this.btnStartPvE.Name = "btnStartPvE";
            this.btnStartPvE.Size = new System.Drawing.Size(303, 85);
            this.btnStartPvE.TabIndex = 4;
            this.btnStartPvE.TabStop = false;
            this.btnStartPvE.Text = "Start";
            this.btnStartPvE.UseVisualStyleBackColor = true;
            this.btnStartPvE.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(23, 239);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(303, 85);
            this.btnBack.TabIndex = 4;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Exit";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblGuide
            // 
            this.lblGuide.AutoSize = true;
            this.lblGuide.Font = new System.Drawing.Font("MV Boli", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuide.Location = new System.Drawing.Point(13, 341);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(303, 56);
            this.lblGuide.TabIndex = 3;
            this.lblGuide.Text = "5 line to win";
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlChessBoard.Location = new System.Drawing.Point(362, 12);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(921, 705);
            this.pnlChessBoard.TabIndex = 5;
            this.pnlChessBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChessBoard_Paint);
            this.pnlChessBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlChessBoard_MouseClick);
            // 
            // pnlPicture
            // 
            this.pnlPicture.BackColor = System.Drawing.Color.LemonChiffon;
            this.pnlPicture.BackgroundImage = global::CaroGame.Properties.Resources.Caro;
            this.pnlPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPicture.Location = new System.Drawing.Point(13, 12);
            this.pnlPicture.Name = "pnlPicture";
            this.pnlPicture.Size = new System.Drawing.Size(343, 343);
            this.pnlPicture.TabIndex = 4;
            // 
            // frmPvC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 728);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlChessBoard);
            this.Controls.Add(this.pnlPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPvC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPvC";
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Button btnBackMenu;
        private System.Windows.Forms.Button btnStartPvE;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblGuide;
        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.Panel pnlPicture;
    }
}