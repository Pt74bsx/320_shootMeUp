namespace ShootMeUp
{
    public class EnemyProjectile
    {
        public float x;
        public float y;
        private float _speedX;
        private float _speedY;
        public Enemy Owner { get; private set; }

        public EnemyProjectile(float x, float y, Enemy owner, float targetX, float targetY)
        {
            this.x = x;
            this.y = y;
            Owner = owner;
            float startX = x + Config.ENEMY_PROJECTILE_WIDTH / 2f;
            float startY = y + Config.ENEMY_PROJECTILE_HEIGHT / 2f;
            float dx = targetX - startX;
            float dy = targetY - startY;
            double distance = Math.Sqrt(dx * dx + dy * dy);
            if (distance > 0)
            {
                float directionX = (float)(dx / distance);
                float directionY = (float)(dy / distance);
                _speedX = directionX * Config.ENEMY_PROJECTILE_SPEED;
                _speedY = directionY * Config.ENEMY_PROJECTILE_SPEED;
            }
            else
            {
                _speedY = Config.ENEMY_PROJECTILE_SPEED;
            }
        }

        public void Update(float elapsedTime)
        {
            x += _speedX * elapsedTime;
            y += _speedY * elapsedTime;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            // IA : effets transparents autour du projectile font pas partie de la collision
            int width = 44;
            int height = 58;
            int offsetX = 15;
            int offsetY = 16;

            if (Owner.Type == 1)
            {
                width = 34;
                height = 67;
                offsetX = 12;
                offsetY = 23;
            }
            else if (Owner.Type == 2)
            {
                width = 25;
                height = 33;
                offsetX = 6;
                offsetY = 0;
            }

            drawingSpace.Graphics.DrawImage(EnemyPictureHelper.GetProjectileImage(Owner.Type), x - offsetX, y - offsetY, width, height);
        }

        public Rectangle Bounds()
        {
            return new Rectangle((int)x, (int)y, Config.ENEMY_PROJECTILE_WIDTH, Config.ENEMY_PROJECTILE_HEIGHT);
        }
    }
}
