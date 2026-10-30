namespace ShootMeUp
{
    public class EnemyHelper
    {
        private readonly Random _random = new Random();

        public List<Enemy> Enemies { get; private set; } = new List<Enemy>();

        public List<EnemyProjectile> Projectiles { get; private set; } = new List<EnemyProjectile>();

        public void Reset()
        {
            Enemies.Clear();
            Projectiles.Clear();
            AddEnemies(Config.ENEMY_START_COUNT);
        }

        public bool IsFree(int column, int row)
        {
            if (column < 0 || column >= Config.ENEMY_COLUMNS || row < 0 || row >= Config.ENEMY_ROWS)
            {
                return false;
            }

            foreach (Enemy enemy in Enemies)
            {
                if (enemy.Column == column && enemy.Row == row)
                {
                    return false;
                }

                if (enemy.IsMoving && enemy.TargetColumn == column && enemy.TargetRow == row)
                {
                    return false;
                }
            }

            return true;
        }

        public void AddEnemies(int count)
        {
            List<Point> positions = new List<Point>();

            for (int row = 0; row < Config.ENEMY_ROWS; row++)
            {
                for (int column = 0; column < Config.ENEMY_COLUMNS; column++)
                {
                    if (IsFree(column, row))
                    {
                        positions.Add(new Point(column, row));
                    }
                }
            }

            for (int i = 0; i < count; i++)
            {
                if (positions.Count == 0 || Enemies.Count >= Config.ENEMY_MAX_COUNT)
                {
                    break;
                }

                int index = _random.Next(positions.Count);

                Point position = positions[index];

                Enemy enemy = new Enemy(position.X, position.Y);

                enemy.ShootCooldown = 2f + _random.Next(2000) / 1000f;
                enemy.MoveTime = Config.ENEMY_MOVE_TIME + _random.Next(2000) / 1000f;

                Enemies.Add(enemy);
                positions.RemoveAt(index);
            }
        }

        public void Update(float elapsedTime, int screenWidth, int screenHeight, Pinguin player)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.UpdateAnimation(elapsedTime);
                enemy.ShootCooldown -= elapsedTime;

                if (enemy.IsMoving)
                {
                    enemy.UpdateMovement(elapsedTime, screenWidth, screenHeight);
                }

                else if (enemy.ShootTime > 0)
                {
                    enemy.ShootTime -= elapsedTime;

                    if (enemy.ShootTime <= 0)
                    {
                        CreateProjectile(enemy, screenWidth, screenHeight, player);
                        enemy.ShootCooldown = Config.ENEMY_SHOOT_COOLDOWN;
                    }
                }

                else
                {
                    enemy.MoveTime -= elapsedTime;

                    if (enemy.MoveTime <= 0)
                    {
                        MoveEnemy(enemy);
                        enemy.MoveTime = Config.ENEMY_MOVE_TIME + _random.Next(2000) / 1000f;
                    }

                    else if (enemy.ShootCooldown <= 0 && !HasProjectile(enemy))
                    {
                        enemy.ShootTime = Config.ENEMY_SHOOT_TIME;
                    }
                }
            }

            foreach (EnemyProjectile projectile in Projectiles)
            {
                projectile.Update(elapsedTime);
            }
        }

        private void MoveEnemy(Enemy enemy)
        {
            int direction = _random.Next(4);
            int column = enemy.Column;
            int row = enemy.Row;

            if (direction == 0)
            {
                column--;
            }

            else if (direction == 1)
            {
                column++;
            }

            else if (direction == 2)
            {
                row++;
            }

            else
            {
                row--;
            }

            if (IsFree(column, row))
            {
                enemy.Move(column, row, direction);
            }
        }

        public int HitBySnowball(Snowball snowball, int screenWidth, int screenHeight)
        {
            Rectangle ball = new Rectangle((int)snowball.x + 30, (int)snowball.y + 30, Config.SNOWBALL_WIDTH - 60, Config.SNOWBALL_HEIGHT - 60);

            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                Enemy enemy = Enemies[i];

                if (ball.IntersectsWith(enemy.Bounds(screenWidth, screenHeight)))
                {
                    if (enemy.loseLife())
                    {
                        Enemies.RemoveAt(i);
                        Reinforce();
                        return enemy.Points;
                    }
                    return 0;
                }
            }
            return -1;
        }


        public void Reinforce()
        {
            if (Enemies.Count <= 2)
            {
                AddEnemies(5);
            }
        }

        private void CreateProjectile(Enemy enemy, int screenWidth, int screenHeight, Pinguin player)
        {
            Rectangle bounds = enemy.Bounds(screenWidth, screenHeight);

            float x = bounds.X + (bounds.Width - Config.ENEMY_PROJECTILE_WIDTH) / 2;
            float targetX = player.x + Config.PINGUIN_WIDTH / 2;
            float targetY = player.y + Config.PINGUIN_HEIGHT / 2;

            Projectiles.Add(new EnemyProjectile(x, bounds.Bottom, enemy, targetX, targetY));
        }

        private bool HasProjectile(Enemy enemy)
        {
            foreach (EnemyProjectile projectile in Projectiles)

            {
                if (projectile.Owner == enemy)

                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveProjectile(int index)
        {
            Projectiles.RemoveAt(index);
        }
    }
}