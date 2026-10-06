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
            SuspendLayout();
            // 
            // GameSpace
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.AliceBlue;
            BackgroundImage = Properties.Resources.gameMape;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1200, 600);
            Cursor = Cursors.Cross;
            KeyPreview = true;
            Name = "GameSpace";
            Text = "GameSpace";
            KeyDown += GameSpace_KeyDown;
            KeyUp += GameSpace_KeyUp;
            Resize += GameSpace_Resize;
            ResumeLayout(false);
        }

        #endregion
    }
}
