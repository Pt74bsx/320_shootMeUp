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
            btnLeave = new Button();
            btnCredit = new Button();
            SuspendLayout();
            // 
            // btnLeave
            // 
            btnLeave.BackColor = Color.Transparent;
            btnLeave.BackgroundImage = (Image)resources.GetObject("btnLeave.BackgroundImage");
            btnLeave.BackgroundImageLayout = ImageLayout.Stretch;
            btnLeave.FlatAppearance.BorderSize = 0;
            btnLeave.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLeave.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLeave.FlatStyle = FlatStyle.Flat;
            btnLeave.Location = new Point(301, 317);
            btnLeave.Name = "btnLeave";
            btnLeave.Size = new Size(198, 76);
            btnLeave.TabIndex = 0;
            btnLeave.UseVisualStyleBackColor = false;
            btnLeave.Click += btnLeave_Click;
            btnLeave.MouseHover += btnLeave_MouseHover;
            // 
            // btnCredit
            // 
            btnCredit.BackgroundImageLayout = ImageLayout.Stretch;
            btnCredit.Location = new Point(621, 382);
            btnCredit.Name = "btnCredit";
            btnCredit.Size = new Size(55, 38);
            btnCredit.TabIndex = 1;
            btnCredit.Text = "Credit";
            btnCredit.UseVisualStyleBackColor = true;
            btnCredit.Click += btnCredit_Click;
            // 
            // HomeSpace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCredit);
            Controls.Add(btnLeave);
            Name = "HomeSpace";
            Text = "HomeSpace";
            ResumeLayout(false);
        }

        #endregion

        private Button btnLeave;
        private Button btnCredit;
    }
}