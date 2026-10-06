namespace ShootMeUp
{
    partial class HomeSpace
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeSpace));
            tableLayoutPanel1 = new TableLayoutPanel();
            btnPlay = new Button();
            btnLeave = new Button();
            btnCredit = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(btnLeave, 1, 3);
            tableLayoutPanel1.Controls.Add(btnCredit, 2, 5);
            tableLayoutPanel1.Controls.Add(btnPlay, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 2.83333325F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.166666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 3F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19F));
            tableLayoutPanel1.Size = new Size(1200, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPlay.BackColor = Color.Transparent;
            btnPlay.BackgroundImage = Properties.Resources.btn_play;
            btnPlay.BackgroundImageLayout = ImageLayout.Zoom;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPlay.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Location = new Point(390, 283);
            btnPlay.Margin = new Padding(30, 8, 30, 8);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(420, 81);
            btnPlay.TabIndex = 0;
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            btnPlay.Enter += btnPlay_MouseHover;
            btnPlay.Leave += btnPlay_MouseLeave;
            btnPlay.MouseEnter += btnPlay_MouseHover;
            btnPlay.MouseLeave += btnPlay_MouseLeave;
            btnPlay.MouseHover += btnPlay_MouseHover;
            // 
            // btnLeave
            // 
            btnLeave.BackColor = Color.Transparent;
            btnLeave.BackgroundImage = Properties.Resources.btn_leave;
            btnLeave.BackgroundImageLayout = ImageLayout.Zoom;
            btnLeave.Dock = DockStyle.Fill;
            btnLeave.FlatAppearance.BorderSize = 0;
            btnLeave.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLeave.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLeave.FlatStyle = FlatStyle.Flat;
            btnLeave.Location = new Point(390, 380);
            btnLeave.Margin = new Padding(30, 8, 30, 8);
            btnLeave.Name = "btnLeave";
            btnLeave.Size = new Size(420, 80);
            btnLeave.TabIndex = 1;
            btnLeave.UseVisualStyleBackColor = false;
            btnLeave.Click += btnLeave_Click;
            btnLeave.Enter += btnLeave_MouseHover;
            btnLeave.Leave += btnLeave_MouseLeave;
            btnLeave.MouseEnter += btnLeave_MouseHover;
            btnLeave.MouseLeave += btnLeave_MouseLeave;
            btnLeave.MouseHover += btnLeave_MouseHover;
            // 
            // btnCredit
            // 
            btnCredit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCredit.BackColor = Color.Transparent;
            btnCredit.BackgroundImage = Properties.Resources.btn_credit;
            btnCredit.BackgroundImageLayout = ImageLayout.Zoom;
            btnCredit.FlatAppearance.BorderSize = 0;
            btnCredit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCredit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCredit.FlatStyle = FlatStyle.Flat;
            btnCredit.Location = new Point(848, 494);
            btnCredit.Margin = new Padding(8, 8, 18, 12);
            btnCredit.Name = "btnCredit";
            btnCredit.Size = new Size(334, 94);
            btnCredit.TabIndex = 2;
            btnCredit.UseVisualStyleBackColor = false;
            btnCredit.Click += btnCredit_Click;
            btnCredit.Enter += btnCredit_MouseHover;
            btnCredit.Leave += btnCredit_MouseLeave;
            btnCredit.MouseEnter += btnCredit_MouseHover;
            btnCredit.MouseLeave += btnCredit_MouseLeave;
            btnCredit.MouseHover += btnCredit_MouseHover;
            // 
            // HomeSpace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1200, 600);
            Controls.Add(tableLayoutPanel1);
            Name = "HomeSpace";
            Text = "HomeSpace";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnPlay;
        private Button btnLeave;
        private Button btnCredit;
    }
}
