namespace ShootMeUp
{
    public partial class GameSpace : Form
    {
        private readonly Pinguin _player = new Pinguin((Config.SCREEN_WIDTH - Config.PINGUIN_WIDTH) / 2, Config.SCREEN_HEIGHT - Config.PINGUIN_HEIGHT);
        private readonly System.Diagnostics.Stopwatch _clock = new System.Diagnostics.Stopwatch();

        private bool _keyA = false;
        private bool _keyLeft = false;
        private bool _keyD = false;
        private bool _keyRight = false;
        private bool _stopRequested = false;

        public GameSpace()
        {
            InitializeComponent();
            DoubleBuffered = true;

            components ??= new System.ComponentModel.Container();
            System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer(components);
            gameTimer.Interval = 16;
            gameTimer.Tick += GameTimer_Tick;
            Deactivate += GameSpace_Deactivate;

            _clock.Start();
            gameTimer.Start();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (ClientSize.Width <= 0 || ClientSize.Height <= 0)
                return;

            using (BufferedGraphics airspace = BufferedGraphicsManager.Current.Allocate(e.Graphics, ClientRectangle))
            {
                airspace.Graphics.Clear(Color.AliceBlue);
                airspace.Graphics.DrawImage(Properties.Resources.gameMape, ClientRectangle);
                _player.Render(airspace);
                airspace.Render(e.Graphics);
            }
        }

        private void GameTimer_Tick(object? sender, EventArgs e)
        {
            float elapsedTime = (float)_clock.Elapsed.TotalSeconds;
            _clock.Restart();

            if (elapsedTime > 0.1f)
            {
                elapsedTime = 0.1f;
            }

            if (_stopRequested)
            {
                _player.Stop();
                _stopRequested = false;
            }
            else if ((_keyA || _keyLeft) && !(_keyD || _keyRight))
            {
                _player.GoLeft();
            }
            else if ((_keyD || _keyRight) && !(_keyA || _keyLeft))
            {
                _player.GoRight();
            }
            else
            {
                _player.Stop();
            }

            _player.Update(elapsedTime, ClientSize.Width);
            Invalidate();
        }

        private void GameSpace_Resize(object? sender, EventArgs e)
        {
            _player.Update(0, ClientSize.Width);
            _player.y = ClientSize.Height - Config.PINGUIN_HEIGHT;
            Invalidate();
        }

        private void GameSpace_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    _keyA = true;
                    break;

                case Keys.Left:
                    _keyLeft = true;
                    break;

                case Keys.D:
                    _keyD = true;
                    break;

                case Keys.Right:
                    _keyRight = true;
                    break;

                default:
                    return;
            }

            e.SuppressKeyPress = true;
        }

        private void GameSpace_KeyUp(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    _keyA = false;
                    break;

                case Keys.Left:
                    _keyLeft = false;
                    break;

                case Keys.D:
                    _keyD = false;
                    break;

                case Keys.Right:
                    _keyRight = false;
                    break;

                default:
                    return;
            }

            _player.Stop();
            _stopRequested = true;
            e.SuppressKeyPress = true;
            Refresh();
        }

        private void GameSpace_Deactivate(object? sender, EventArgs e)
        {
            _keyA = false;
            _keyLeft = false;
            _keyD = false;
            _keyRight = false;
            _player.Stop();
            _stopRequested = true;
            Invalidate();
        }
    }
}
