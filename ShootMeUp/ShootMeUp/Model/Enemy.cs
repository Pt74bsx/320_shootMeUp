namespace ShootMeUp
{
    public class Enemy
    {
        public int Column { get; private set; }
        public int Row { get; private set; }

        public int TargetColumn { get; private set; }
        public int TargetRow { get; private set; }
        public bool IsMoving { get; private set; }
        private float _moveDistance;

        public int Type { get; private set; }
        public int Lives { get; private set; }
        public int Points { get; private set; }

        public float ShootCooldown { get; set; }
        public float ShootTime { get; set; }
        public float MoveTime { get; set; }

        public int Direction { get; private set; }
        public float AnimationTime { get; private set; }

        public void UpdateAnimation(float elapsedTime)
        {
            AnimationTime += elapsedTime;
            if (AnimationTime >= 1)
            {
                AnimationTime -= 1;
            }
        }

        public void Render(BufferedGraphics drawingSpace, int screenWidth, int screenHeight)
        {
            Rectangle position = Bounds(screenWidth, screenHeight);
            int imageHeight = 128;
            int bottomMargin = 9;

            // Les image ont pas toutes les memes marges 
            if (Type == 1)
            {
                imageHeight = 122;
                bottomMargin = 12;
            }
            else if (Type == 2)
            {
                imageHeight = 130;
                bottomMargin = 0;
            }

            drawingSpace.Graphics.DrawImage(EnemyPictureHelper.GetImage(this), position.X, position.Bottom - imageHeight + bottomMargin, position.Width, imageHeight);
        }

        public Enemy(int column, int row)
        {
            Column = column;
            Row = row;
            TargetColumn = column;
            TargetRow = row;
            Type = row;
            Lives = row + 1;
            Points = Lives * 10;
        }

        public void Move(int column, int row, int direction)
        {
            if (IsMoving || ShootTime > 0)
            {
                return;
            }

            TargetColumn = column;
            TargetRow = row;
            _moveDistance = 0;
            IsMoving = true;
            Direction = direction;
        }

        public void UpdateMovement(float elapsedTime, int screenWidth, int screenHeight)
        {
            if (!IsMoving)
            {
                return;
            }

            Point start = CellPosition(Column, Row, screenWidth, screenHeight);
            Point target = CellPosition(TargetColumn, TargetRow, screenWidth, screenHeight);

            // le déplacement est horizontal ou vertical
            int distanceX = Math.Abs(target.X - start.X);
            int distanceY = Math.Abs(target.Y - start.Y);
            int distance = distanceX + distanceY;

            _moveDistance += Config.ENEMY_SPEED * elapsedTime;

            if (_moveDistance >= distance)
            {
                Column = TargetColumn;
                Row = TargetRow;
                _moveDistance = 0;
                IsMoving = false;
            }
        }

        public bool loseLife()
        {
            if (Lives > 0)
            {
                Lives--;
            }
            return Lives == 0;
        }

        public Rectangle Bounds(int screenWidth, int screenHeight)
        {
            Point position = CellPosition(Column, Row, screenWidth, screenHeight);
            if (IsMoving)
            {
                Point target = CellPosition(TargetColumn, TargetRow, screenWidth, screenHeight);
                int distance = Math.Abs(target.X - position.X) + Math.Abs(target.Y - position.Y);
                int moved = (int)_moveDistance;
                if (moved > distance)
                {
                    moved = distance;
                }

                if (target.X > position.X)
                {
                    position.X += moved;
                }
                else if (target.X < position.X)
                {
                    position.X -= moved;
                }
                else if (target.Y > position.Y)
                {
                    position.Y += moved;
                }
                else
                {
                    position.Y -= moved;
                }
            }
            return new Rectangle(position.X, position.Y, Config.ENEMY_WIDTH, Config.ENEMY_HEIGHT);
        }

        private Point CellPosition(int column, int row, int screenWidth, int screenHeight)
        {
            int x = screenWidth * (column + 1) / (Config.ENEMY_COLUMNS + 1);

            // IA : Trois lignes de 80 pixels tiennent au dessus des protections meme à 540 pixele
            int bottomRow = screenHeight - 380;
            int rowFromTop = Config.ENEMY_ROWS - 1 - row;
            int y = bottomRow * rowFromTop / (Config.ENEMY_ROWS - 1);
            return new Point(x - Config.ENEMY_WIDTH / 2, y);
        }
    }
}
