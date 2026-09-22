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
            SuspendLayout();
            // 
            // btnCredit
            // 
            btnCredit.BackgroundImageLayout = ImageLayout.Stretch;
            btnCredit.Location = new Point(638, 383);
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
            Name = "HomeSpace";
            Text = "HomeSpace";
            ResumeLayout(false);
        }

        #endregion
        private Button btnCredit;
    }
}