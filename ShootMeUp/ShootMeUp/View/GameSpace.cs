namespace ShootMeUp
{
    public partial class GameSpace : Form
    {
        private readonly Pinguin _player = new Pinguin((Config.SCREEN_WIDTH - Config.PINGUIN_WIDTH) / 2, Config.SCREEN_HEIGHT - Config.PINGUIN_HEIGHT);

        private readonly List<Snowball> _snowballs = new List<Snowball>();

        private readonly List<Protection> _protection = new List<Protection>();

        private readonly System.Diagnostics.Stopwatch _clock = new System.Diagnostics.Stopwatch();

        private bool _keyA = false;
        private bool _keyLeft = false;
        private bool _keyD = false;
        private bool _keyRight = false;
        private bool _stopRequested = false;

        private bool _isShoot = false;
        private float _shootTime = 0;
        private float _shootCooldown = 0;

        public GameSpace()
        {
            InitializeComponent();
            ResponsiveHelpers.ConfigureScreen(this);
            DoubleBuffered = true;

            components ??= new System.ComponentModel.Container();
            System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer(components);
            gameTimer.Interval = 16;
            gameTimer.Tick += GameTimer_Tick;
            Cursor.Hide();

            Deactivate += GameSpace_Deactivate;
            MouseDown += GameSpace_MouseDown;

            _clock.Start();
            gameTimer.Start();

            for (int i = 0; i < 5; i++)
            {
                _protection.Add(new Protection(0, 0));
            }

            PositionProtections();
        }

        private void PositionProtections()
        {
            if (_protection.Count < 5)
                return;

            int w = ClientSize.Width;
            int pw = Config.PROTECTION_WIDTH;

            int y = ClientSize.Height - Config.PINGUIN_HEIGHT - Config.PROTECTION_HEIGHT - 20;

            _protection[0].SetPosition(w / 10 - pw / 2, y);
            _protection[1].SetPosition(w * 3 / 10 - pw / 2, y - 50);
            _protection[2].SetPosition((w - pw) / 2, y);
            _protection[3].SetPosition(w * 7 / 10 - pw / 2, y - 50);
            _protection[4].SetPosition(w * 9 / 10 - pw / 2, y);
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

                foreach (Snowball snowball in _snowballs)
                {
                    snowball.Render(airspace);
                }

                foreach (Protection protection in _protection)
                {
                    protection.Render(airspace);
                }

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

            if (_shootCooldown > 0)
            {
                _shootCooldown -= elapsedTime;
            }

            if (_isShoot)
            {
                _shootTime -= elapsedTime;

                if (_shootTime <= 0)
                {
                    CreateSnowball();

                    _player.shootPinguin = false;
                    _isShoot = false;
                }
            }
            else
            {
                MovePlayer();
            }

            _player.Update(elapsedTime, ClientSize.Width);

            for (int i = _snowballs.Count - 1; i >= 0; i--)
            {
                _snowballs[i].Update(elapsedTime);

                bool touched = false;

                for (int j = _protection.Count - 1; j >= 0; j--)
                {
                    if (_protection[j].touched(_snowballs[i])) 
                    {
                        if (_protection[j].loseLife())
                        {
                            _protection.RemoveAt(j);
                        }

                        _snowballs.RemoveAt(i);
                        touched = true;
                        break;
                    }
                }

                if (touched)
                {
                    continue;
                }

                if (_snowballs[i].y + Config.SNOWBALL_HEIGHT < 0)
                {
                    _snowballs.RemoveAt(i);
                }
            }

            Invalidate();
        }

        private void MovePlayer()
        {
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
        }

        private void Shoot()
        {
            if (_isShoot || _shootCooldown > 0)
                return;

            _player.Shoot();

            _isShoot = true;
            _shootTime = Config.SHOOT_TIME / 1000f;
            _shootCooldown = Config.SHOOT_COOLDOWN / 1000f;
        }

        private void CreateSnowball()
        {
            float x = _player.x + (Config.PINGUIN_WIDTH - Config.SNOWBALL_WIDTH) / 2;

            float y = _player.y;

            _snowballs.Add(new Snowball(x, y));
        }

        private void GameSpace_Resize(object? sender, EventArgs e)
        {
            _player.Update(0, ClientSize.Width);
            _player.y = ClientSize.Height - Config.PINGUIN_HEIGHT;

            PositionProtections();
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

                case Keys.Space:
                    Shoot();
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

        private void GameSpace_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Shoot();
            }
        }
    }
}
