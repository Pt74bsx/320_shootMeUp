namespace ShootMeUp
{
    public partial class GameSpace : Form
    {
        public HealthHelper Health { get; private set; } = new HealthHelper();
        public ScoreHelper Score { get; private set; } = new ScoreHelper();

        private readonly EnemyHelper _enemies = new EnemyHelper();
        private Image? _background;

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

            if (components == null)
            {
                components = new System.ComponentModel.Container();
            }

            System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer(components);
            gameTimer.Interval = 16;
            gameTimer.Tick += GameTimer_Tick;

            Deactivate += GameSpace_Deactivate;
            Disposed += GameSpace_Disposed;

            _clock.Start();
            gameTimer.Start();

            for (int i = 0; i < 5; i++)
            {
                _protection.Add(new Protection(0, 0, i));
            }

            _enemies.Reset();
            PositionProtections();
            UpdateLabels();
        }

        private void PositionProtections()
        {
            int w = ClientSize.Width;
            int pw = Config.PROTECTION_WIDTH;

            int y = ClientSize.Height - Config.PINGUIN_HEIGHT - Config.PROTECTION_HEIGHT - 20;

            // IA : calcule selon la taille de l’écran
            foreach (Protection protection in _protection)
            {
                int x = w * (protection.Slot * 2 + 1) / 10 - pw / 2;
                int height = y;
                if (protection.Slot == 1 || protection.Slot == 3)
                {
                    height -= 50;
                }
                protection.SetPosition(x, height);
            }
        }

        public void PlayerTouched()
        {
            Health.loseLife();
            UpdateLabels();

            if (Health.IsFinished)
            {
                _player.Stop();
                _player.shootPinguin = false;
                _isShoot = false;

                SpaceManager.End.SetScore(Score.Points);

                SpaceManager.End.Show();
                this.Hide();
            }

            Invalidate();
        }

        private void UpdateLabels()
        {
            valueScore.Text = "" + Score.Points;

            pbLife1.Visible = Health.Lives >= 1;
            pbLife2.Visible = Health.Lives >= 2;
            pbLife3.Visible = Health.Lives >= 3;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (ClientSize.Width <= 0 || ClientSize.Height <= 0)
                return;

            // IA : réutiliser le fond jusqu'au redimensionnement
            if (_background == null || _background.Size != ClientSize)
            {
                if (_background != null)
                {
                    _background.Dispose();
                }
                _background = PictureHelper.ResizeImage(Properties.Resources.gameMape, ClientSize.Width, ClientSize.Height);
            }

            using (BufferedGraphics airspace = BufferedGraphicsManager.Current.Allocate(e.Graphics, ClientRectangle))
            {
                airspace.Graphics.Clear(Color.AliceBlue);
                airspace.Graphics.DrawImage(_background, ClientRectangle);
                _player.Render(airspace);

                foreach (Enemy enemy in _enemies.Enemies)
                {
                    enemy.Render(airspace, ClientSize.Width, ClientSize.Height);
                }

                foreach (EnemyProjectile projectile in _enemies.Projectiles)
                {
                    projectile.Render(airspace);
                }

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

        private void GameSpace_Disposed(object? sender, EventArgs e)
        {
            if (_background != null)
            {
                _background.Dispose();
            }
        }

        private void GameTimer_Tick(object? sender, EventArgs e)
        {
            float elapsedTime = (float)_clock.Elapsed.TotalSeconds;
            _clock.Restart();

            // pause si le jeu est psa actif
            if (!Visible || !ContainsFocus || Health.IsFinished)
            {
                return;
            }

            UpdateGame(elapsedTime);
        }

        public void UpdateGame(float elapsedTime)
        {
            if (Health.IsFinished || elapsedTime <= 0)
            {
                return;
            }

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
            _enemies.Update(elapsedTime, ClientSize.Width, ClientSize.Height, _player);
            UpdateSnowballs(elapsedTime);
            UpdateEnemyProjectiles();
            Invalidate();
        }

        private void UpdateSnowballs(float elapsedTime)
        {
            for (int i = _snowballs.Count - 1; i >= 0; i--)
            {
                _snowballs[i].Update(elapsedTime);

                bool touched = false;

                for (int j = _protection.Count - 1; j >= 0; j--)
                {
                    if (_protection[j].touched(_snowballs[i]))
                    {


                        _snowballs.RemoveAt(i);
                        touched = true;
                        break;
                    }
                }

                if (touched)
                {
                    continue;
                }

                int points = _enemies.HitBySnowball(_snowballs[i], ClientSize.Width, ClientSize.Height);
                if (points >= 0)
                {
                    Score.AddScore(points);
                    UpdateLabels();
                    _snowballs.RemoveAt(i);
                    continue;
                }

                if (_snowballs[i].y + Config.SNOWBALL_HEIGHT < 0)
                {
                    _snowballs.RemoveAt(i);
                }
            }

        }

        private void UpdateEnemyProjectiles()
        {
            for (int i = _enemies.Projectiles.Count - 1; i >= 0; i--)
            {
                EnemyProjectile projectile = _enemies.Projectiles[i];

                bool touched = false;
                for (int j = _protection.Count - 1; j >= 0; j--)
                {
                    if (_protection[j].touched(projectile))
                    {
                        if (_protection[j].loseLife())
                        {
                            _protection.RemoveAt(j);
                        }
                        touched = true;
                        break;
                    }
                }

                if (!touched && _player.touched(projectile))
                {
                    PlayerTouched();
                    touched = true;
                }

                if (touched || projectile.y > ClientSize.Height ||
                    projectile.x + Config.ENEMY_PROJECTILE_WIDTH < 0 || projectile.x > ClientSize.Width ||
                    projectile.y + Config.ENEMY_PROJECTILE_HEIGHT < 0)
                {
                    _enemies.RemoveProjectile(i);
                }
                if (Health.IsFinished)
                {
                    break;
                }
            }
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
            if (Health.IsFinished || _isShoot || _shootCooldown > 0)
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
            Invalidate();
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

        /// <summary>
        /// Permet de remettre toutes les valeurs
        /// utilisées dans le jeux à leurs valeurs 
        /// initiale 
        /// </summary>
        public void ResetGame()
        {
            // Vies et score 
            Health.Reset();
            Score.Reset();
            UpdateLabels();

            // Touches
            _keyA = false;
            _keyD = false;
            _keyLeft = false;
            _keyRight = false;
            _stopRequested = false;

            // Tir
            _isShoot = false;
            _shootTime = 0;
            _shootCooldown = 0;

            // Pinguin
            _player.Stop();
            _player.shootPinguin = false;
            _player.x = (ClientSize.Width - Config.PINGUIN_WIDTH) / 2;
            _player.y = ClientSize.Height - Config.PINGUIN_HEIGHT;
            _snowballs.Clear();

            // enemis
            _enemies.Reset();

            // protections
            _protection.Clear();

            for (int i = 0; i < 5; i++)
            {
                _protection.Add(new Protection(0, 0, i));
            }

            PositionProtections();

            // chronomètre
            _clock.Reset();

            Invalidate();
        }
    }
}
