namespace TetrisGame
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TimFrame = new System.Windows.Forms.Timer(this.components);
            this.TimTime = new System.Windows.Forms.Timer(this.components);
            this.PicClose = new System.Windows.Forms.PictureBox();
            this.PicStart = new System.Windows.Forms.PictureBox();
            this.LblScore = new System.Windows.Forms.Label();
            this.LblLines = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.LblLevel = new System.Windows.Forms.Label();
            this.LblKeys = new System.Windows.Forms.Label();
            this.LblHighscore = new System.Windows.Forms.Label();
            this.TimLift = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.LblMusictoggle = new System.Windows.Forms.Label();
            this.pnlGame = new TetrisGame.PnlGame();
            ((System.ComponentModel.ISupportInitialize)(this.PicClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // TimFrame
            // 
            this.TimFrame.Interval = 1000;
            this.TimFrame.Tick += new System.EventHandler(this.TimFrame_Tick);
            // 
            // TimTime
            // 
            this.TimTime.Interval = 1000;
            this.TimTime.Tick += new System.EventHandler(this.TimTime_Tick);
            // 
            // PicClose
            // 
            this.PicClose.Location = new System.Drawing.Point(796, 583);
            this.PicClose.Name = "PicClose";
            this.PicClose.Size = new System.Drawing.Size(200, 90);
            this.PicClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicClose.TabIndex = 13;
            this.PicClose.TabStop = false;
            this.PicClose.Click += new System.EventHandler(this.PicClose_Click);
            // 
            // PicStart
            // 
            this.PicStart.Location = new System.Drawing.Point(571, 583);
            this.PicStart.Name = "PicStart";
            this.PicStart.Size = new System.Drawing.Size(200, 90);
            this.PicStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicStart.TabIndex = 14;
            this.PicStart.TabStop = false;
            this.PicStart.Click += new System.EventHandler(this.PicStart_Click);
            // 
            // LblScore
            // 
            this.LblScore.AutoSize = true;
            this.LblScore.BackColor = System.Drawing.Color.White;
            this.LblScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblScore.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblScore.Location = new System.Drawing.Point(518, 264);
            this.LblScore.MaximumSize = new System.Drawing.Size(150, 50);
            this.LblScore.MinimumSize = new System.Drawing.Size(150, 2);
            this.LblScore.Name = "LblScore";
            this.LblScore.Size = new System.Drawing.Size(150, 38);
            this.LblScore.TabIndex = 15;
            this.LblScore.Text = "0";
            this.LblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblLines
            // 
            this.LblLines.AutoSize = true;
            this.LblLines.BackColor = System.Drawing.Color.White;
            this.LblLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLines.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLines.Location = new System.Drawing.Point(518, 317);
            this.LblLines.MaximumSize = new System.Drawing.Size(150, 50);
            this.LblLines.MinimumSize = new System.Drawing.Size(150, 2);
            this.LblLines.Name = "LblLines";
            this.LblLines.Size = new System.Drawing.Size(150, 38);
            this.LblLines.TabIndex = 16;
            this.LblLines.Text = "0";
            this.LblLines.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.BackColor = System.Drawing.Color.White;
            this.LblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTime.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTime.Location = new System.Drawing.Point(518, 370);
            this.LblTime.MaximumSize = new System.Drawing.Size(150, 50);
            this.LblTime.MinimumSize = new System.Drawing.Size(150, 2);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(150, 38);
            this.LblTime.TabIndex = 17;
            this.LblTime.Text = "00:00";
            this.LblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblLevel
            // 
            this.LblLevel.AutoSize = true;
            this.LblLevel.BackColor = System.Drawing.Color.White;
            this.LblLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblLevel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLevel.Location = new System.Drawing.Point(518, 422);
            this.LblLevel.MaximumSize = new System.Drawing.Size(150, 50);
            this.LblLevel.MinimumSize = new System.Drawing.Size(150, 2);
            this.LblLevel.Name = "LblLevel";
            this.LblLevel.Size = new System.Drawing.Size(150, 38);
            this.LblLevel.TabIndex = 18;
            this.LblLevel.Text = "1";
            this.LblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblKeys
            // 
            this.LblKeys.AutoSize = true;
            this.LblKeys.BackColor = System.Drawing.Color.Transparent;
            this.LblKeys.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblKeys.ForeColor = System.Drawing.Color.White;
            this.LblKeys.Location = new System.Drawing.Point(871, 676);
            this.LblKeys.Name = "LblKeys";
            this.LblKeys.Size = new System.Drawing.Size(125, 91);
            this.LblKeys.TabIndex = 19;
            this.LblKeys.Text = "A - Move block left\r\nD - Move block Right\r\nW - Turn Block\r\nS - Increase speed\r\nSp" +
    "ace bar - Drop block\r\nP - Pause game\r\nBest played in 1024x768";
            // 
            // LblHighscore
            // 
            this.LblHighscore.AutoSize = true;
            this.LblHighscore.BackColor = System.Drawing.Color.Transparent;
            this.LblHighscore.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHighscore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblHighscore.Location = new System.Drawing.Point(518, 506);
            this.LblHighscore.MaximumSize = new System.Drawing.Size(500, 0);
            this.LblHighscore.MinimumSize = new System.Drawing.Size(500, 0);
            this.LblHighscore.Name = "LblHighscore";
            this.LblHighscore.Size = new System.Drawing.Size(500, 36);
            this.LblHighscore.TabIndex = 20;
            this.LblHighscore.Text = "Highscore: ";
            this.LblHighscore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimLift
            // 
            this.TimLift.Interval = 25;
            this.TimLift.Tick += new System.EventHandler(this.TimLift_Tick);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(-15, -15);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 21;
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(556, 706);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(266, 33);
            this.MediaPlayer.TabIndex = 22;
            this.MediaPlayer.Visible = false;
            // 
            // LblMusictoggle
            // 
            this.LblMusictoggle.AutoSize = true;
            this.LblMusictoggle.BackColor = System.Drawing.Color.Transparent;
            this.LblMusictoggle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMusictoggle.ForeColor = System.Drawing.Color.White;
            this.LblMusictoggle.Location = new System.Drawing.Point(568, 690);
            this.LblMusictoggle.Name = "LblMusictoggle";
            this.LblMusictoggle.Size = new System.Drawing.Size(82, 13);
            this.LblMusictoggle.TabIndex = 23;
            this.LblMusictoggle.Text = "Music: On/Off";
            this.LblMusictoggle.Click += new System.EventHandler(this.LblMusictoggle_Click);
            // 
            // pnlGame
            // 
            this.pnlGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGame.Location = new System.Drawing.Point(12, 6);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(500, 750);
            this.pnlGame.TabIndex = 4;
            this.pnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGame_Paint);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.LblMusictoggle);
            this.Controls.Add(this.MediaPlayer);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.LblHighscore);
            this.Controls.Add(this.LblKeys);
            this.Controls.Add(this.LblLevel);
            this.Controls.Add(this.LblTime);
            this.Controls.Add(this.LblLines);
            this.Controls.Add(this.LblScore);
            this.Controls.Add(this.PicStart);
            this.Controls.Add(this.PicClose);
            this.Controls.Add(this.pnlGame);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PicClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TimFrame;
        private PnlGame pnlGame;
        private System.Windows.Forms.Timer TimTime;
        private System.Windows.Forms.PictureBox PicClose;
        private System.Windows.Forms.PictureBox PicStart;
        private System.Windows.Forms.Label LblScore;
        private System.Windows.Forms.Label LblLines;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Label LblLevel;
        private System.Windows.Forms.Label LblKeys;
        private System.Windows.Forms.Label LblHighscore;
        private System.Windows.Forms.Timer TimLift;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        private System.Windows.Forms.Label LblMusictoggle;
    }
}

