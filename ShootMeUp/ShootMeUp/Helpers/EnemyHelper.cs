namespace ShootMeUp
{
    public class EnemyHelper
    {
        private readonly Random _random = new Random();
        public List<Enemy> Enemies { get; private set; } = new List<Enemy>();

        public void Reset()
        {
            Enemies.Clear();
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
    }
}
