namespace ShootMeUp
{
    partial class CreditSpace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditSpace));
            btn_out = new Button();
            SuspendLayout();
            // 
            // btn_out
            // 
            btn_out.BackColor = Color.Transparent;
            btn_out.BackgroundImage = (Image)resources.GetObject("btn_out.BackgroundImage");
            btn_out.BackgroundImageLayout = ImageLayout.Zoom;
            btn_out.FlatAppearance.BorderSize = 0;
            btn_out.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_out.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_out.FlatStyle = FlatStyle.Flat;
            btn_out.ForeColor = Color.Transparent;
            btn_out.Location = new Point(56, 50);
            btn_out.Name = "btn_out";
            btn_out.Size = new Size(76, 65);
            btn_out.TabIndex = 0;
            btn_out.UseVisualStyleBackColor = false;
            btn_out.MouseClick += btn_out_MouseClick;
            btn_out.MouseLeave += btn_out_MouseLeave;
            btn_out.MouseHover += btn_out_MouseHover;
            // 
            // CreditSpace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_out);
            Name = "CreditSpace";
            Text = "CreditSpace";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_out;
    }
}