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
            drawingSpace.Graphics.DrawImage(EnemyImageHelper.GetImage(this),
                position.X, position.Bottom - imageHeight + bottomMargin, position.Width, imageHeight);
        }

        public Enemy(int column, int row)
        {
            Column = column;
            Row = row;
            TargetColumn = column;
            TargetRow = row;
            Type = row;
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

        public Rectangle Bounds(int screenWidth, int screenHeight)
        {
            Point position = CellPosition(Column, Row, screenWidth, screenHeight);
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
