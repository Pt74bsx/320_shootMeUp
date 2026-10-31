namespace ShootMeUp
{
    partial class GameSpace
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pbLife3 = new PictureBox();
            pbLife2 = new PictureBox();
            pbLife1 = new PictureBox();
            valueScore = new Label();
            ScorePanel = new Panel();
            lblScore = new Label();
            ((System.ComponentModel.ISupportInitialize)pbLife3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLife2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLife1).BeginInit();
            ScorePanel.SuspendLayout();
            SuspendLayout();
            // 
            // pbLife3
            // 
            pbLife3.BackColor = Color.Transparent;
            pbLife3.BackgroundImage = Properties.Resources.coeur_vie;
            pbLife3.BackgroundImageLayout = ImageLayout.Zoom;
            pbLife3.Location = new Point(1091, 12);
            pbLife3.Name = "pbLife3";
            pbLife3.Size = new Size(97, 60);
            pbLife3.TabIndex = 0;
            pbLife3.TabStop = false;
            // 
            // pbLife2
            // 
            pbLife2.BackColor = Color.Transparent;
            pbLife2.BackgroundImage = Properties.Resources.coeur_vie;
            pbLife2.BackgroundImageLayout = ImageLayout.Zoom;
            pbLife2.Location = new Point(1016, 12);
            pbLife2.Name = "pbLife2";
            pbLife2.Size = new Size(97, 60);
            pbLife2.TabIndex = 1;
            pbLife2.TabStop = false;
            // 
            // pbLife1
            // 
            pbLife1.BackColor = Color.Transparent;
            pbLife1.BackgroundImage = Properties.Resources.coeur_vie;
            pbLife1.BackgroundImageLayout = ImageLayout.Zoom;
            pbLife1.Location = new Point(952, 12);
            pbLife1.Name = "pbLife1";
            pbLife1.Size = new Size(97, 60);
            pbLife1.TabIndex = 2;
            pbLife1.TabStop = false;
            // 
            // valueScore
            // 
            valueScore.AutoSize = true;
            valueScore.BackColor = Color.Transparent;
            valueScore.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valueScore.ForeColor = Color.DodgerBlue;
            valueScore.Location = new Point(153, 26);
            valueScore.Name = "valueScore";
            valueScore.Size = new Size(25, 25);
            valueScore.TabIndex = 6;
            valueScore.Text = "0";
            // 
            // ScorePanel
            // 
            ScorePanel.BackColor = Color.Transparent;
            ScorePanel.BackgroundImage = Properties.Resources.background_score;
            ScorePanel.BackgroundImageLayout = ImageLayout.Stretch;
            ScorePanel.Controls.Add(lblScore);
            ScorePanel.Controls.Add(valueScore);
            ScorePanel.Location = new Point(0, 0);
            ScorePanel.Margin = new Padding(0);
            ScorePanel.Name = "ScorePanel";
            ScorePanel.Size = new Size(312, 72);
            ScorePanel.TabIndex = 7;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(52, 26);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(95, 25);
            lblScore.TabIndex = 6;
            lblScore.Text = "Score :";
            // 
            // GameSpace
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gameMape;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1200, 600);
            Controls.Add(ScorePanel);
            Controls.Add(pbLife1);
            Controls.Add(pbLife2);
            Controls.Add(pbLife3);
            Cursor = Cursors.Cross;
            KeyPreview = true;
            Name = "GameSpace";
            Text = "GameSpace";
            KeyDown += GameSpace_KeyDown;
            KeyUp += GameSpace_KeyUp;
            MouseDown += GameSpace_MouseDown;
            Resize += GameSpace_Resize;
            ((System.ComponentModel.ISupportInitialize)pbLife3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLife2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLife1).EndInit();
            ScorePanel.ResumeLayout(false);
            ScorePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbLife3;
        private PictureBox pbLife2;
        private PictureBox pbLife1;
        private Label valueScore;
        private Panel ScorePanel;
        private Label lblScore;
    }
}
