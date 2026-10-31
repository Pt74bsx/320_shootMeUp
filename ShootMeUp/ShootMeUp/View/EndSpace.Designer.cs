namespace ShootMeUp
{
    partial class EndSpace
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
            lblEndScore = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnBackToHome = new Button();
            btnReplay = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblEndScore
            // 
            lblEndScore.BackColor = Color.Transparent;
            tableLayoutPanel1.SetColumnSpan(lblEndScore, 2);
            lblEndScore.Dock = DockStyle.Fill;
            lblEndScore.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndScore.ForeColor = Color.DodgerBlue;
            lblEndScore.Location = new Point(3, 204);
            lblEndScore.Name = "lblEndScore";
            lblEndScore.Size = new Size(794, 54);
            lblEndScore.TabIndex = 0;
            lblEndScore.Text = "0000";
            lblEndScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnBackToHome, 1, 4);
            tableLayoutPanel1.Controls.Add(lblEndScore, 0, 1);
            tableLayoutPanel1.Controls.Add(btnReplay, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46.0526352F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.2807016F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 2.63157916F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 3.11111116F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.4444447F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.88889F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnBackToHome
            // 
            btnBackToHome.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnBackToHome.BackColor = Color.Transparent;
            btnBackToHome.BackgroundImage = Properties.Resources.btn_backToHome;
            btnBackToHome.BackgroundImageLayout = ImageLayout.Stretch;
            btnBackToHome.FlatAppearance.BorderSize = 0;
            btnBackToHome.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBackToHome.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBackToHome.FlatStyle = FlatStyle.Flat;
            btnBackToHome.Location = new Point(430, 290);
            btnBackToHome.Margin = new Padding(30, 8, 30, 8);
            btnBackToHome.Name = "btnBackToHome";
            btnBackToHome.Size = new Size(141, 74);
            btnBackToHome.TabIndex = 1;
            btnBackToHome.UseVisualStyleBackColor = false;
            btnBackToHome.Click += btnBackToHome_Click;
            // 
            // btnReplay
            // 
            btnReplay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnReplay.BackColor = Color.Transparent;
            btnReplay.BackgroundImage = Properties.Resources.btn_replay;
            btnReplay.BackgroundImageLayout = ImageLayout.Stretch;
            btnReplay.FlatAppearance.BorderSize = 0;
            btnReplay.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnReplay.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnReplay.FlatStyle = FlatStyle.Flat;
            btnReplay.Location = new Point(229, 290);
            btnReplay.Margin = new Padding(30, 8, 30, 8);
            btnReplay.Name = "btnReplay";
            btnReplay.Size = new Size(141, 74);
            btnReplay.TabIndex = 0;
            btnReplay.UseVisualStyleBackColor = false;
            btnReplay.Click += btnReplay_Click;
            // 
            // EndSpace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_EndSpace;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "EndSpace";
            Text = "EndSpace";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblEndScore;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnBackToHome;
        private Button btnReplay;
    }
}