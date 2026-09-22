namespace ShootMeUp
{
    partial class HomeSpace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeSpace));
            btnCredit = new Button();
            btnLeave = new Button();
            btnPlay = new Button();
            SuspendLayout();
            // 
            // btnCredit
            // 
            btnCredit.BackColor = Color.Transparent;
            btnCredit.BackgroundImage = Properties.Resources.btn_credit;
            btnCredit.BackgroundImageLayout = ImageLayout.Zoom;
            btnCredit.FlatAppearance.BorderSize = 0;
            btnCredit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCredit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCredit.FlatStyle = FlatStyle.Flat;
            btnCredit.Location = new Point(602, 355);
            btnCredit.Name = "btnCredit";
            btnCredit.Size = new Size(91, 65);
            btnCredit.TabIndex = 1;
            btnCredit.UseVisualStyleBackColor = false;
            btnCredit.Click += btnCredit_Click;
            btnCredit.MouseLeave += btnCredit_MouseLeave;
            btnCredit.MouseHover += btnCredit_MouseHover;
            // 
            // btnLeave
            // 
            btnLeave.BackColor = Color.Transparent;
            btnLeave.BackgroundImage = Properties.Resources.btn_leave;
            btnLeave.BackgroundImageLayout = ImageLayout.Zoom;
            btnLeave.FlatAppearance.BorderSize = 0;
            btnLeave.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLeave.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLeave.FlatStyle = FlatStyle.Flat;
            btnLeave.Location = new Point(300, 313);
            btnLeave.Name = "btnLeave";
            btnLeave.Size = new Size(220, 80);
            btnLeave.TabIndex = 2;
            btnLeave.UseVisualStyleBackColor = false;
            btnLeave.Click += btnLeave_Click;
            btnLeave.MouseLeave += btnLeave_MouseLeave;
            btnLeave.MouseHover += btnLeave_MouseHover;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.Transparent;
            btnPlay.BackgroundImage = Properties.Resources.btn_play;
            btnPlay.BackgroundImageLayout = ImageLayout.Zoom;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPlay.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Location = new Point(300, 227);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(220, 80);
            btnPlay.TabIndex = 3;
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            btnPlay.MouseLeave += btnPlay_MouseLeave;
            btnPlay.MouseHover += btnPlay_MouseHover;
            // 
            // HomeSpace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPlay);
            Controls.Add(btnLeave);
            Controls.Add(btnCredit);
            Name = "HomeSpace";
            Text = "HomeSpace";
            ResumeLayout(false);
        }

        #endregion
        private Button btnCredit;
        private Button btnLeave;
        private Button btnPlay;
    }
}