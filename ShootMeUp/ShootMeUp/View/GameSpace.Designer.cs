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
            lblScore = new Label();
            ((System.ComponentModel.ISupportInitialize)pbLife3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLife2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLife1).BeginInit();
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
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(25, 12);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(38, 15);
            lblScore.TabIndex = 3;
            lblScore.Text = "label1";
            // 
            // GameSpace
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gameMape;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1200, 600);
            Controls.Add(lblScore);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbLife3;
        private PictureBox pbLife2;
        private PictureBox pbLife1;
        private Label lblScore;
    }
}
