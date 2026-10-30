using ShootMeUp.Properties;
using System.Drawing;

namespace ShootMeUp
{
    public class Pinguin
    {
        private static readonly Image _pinguinImage = PictureHelper.ResizeImage(Resources.pinguin, Config.PINGUIN_WIDTH, Config.PINGUIN_HEIGHT);
        private static readonly Image _pinguinShootImage = PictureHelper.ResizeImage(Resources.pinguinShoot, Config.PINGUIN_WIDTH, Config.PINGUIN_HEIGHT);
        private static readonly Image _pinguinLeftImage = PictureHelper.ResizeImage(Resources.pinguinLeft, Config.PINGUIN_WIDTH, Config.PINGUIN_HEIGHT);
        private static readonly Image _pinguinRightImage = PictureHelper.ResizeImage(Resources.pinguinRight, Config.PINGUIN_WIDTH, Config.PINGUIN_HEIGHT);

        public enum StateMouvPinguin { LEFT, FIX, RIGHT }

        public float x;
        public int y;

        public bool shootPinguin = false;

        public StateMouvPinguin MouvPinguin { get; private set;  } = StateMouvPinguin.FIX;

        public Pinguin(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Update(float elapsedTime, int screenWidth)
        {
            if (MouvPinguin == StateMouvPinguin.LEFT)
            {
                x -= Config.SPEED * elapsedTime;
            }
            else if (MouvPinguin == StateMouvPinguin.RIGHT)
            {
                x += Config.SPEED * elapsedTime;
            }

            if (x > screenWidth - Config.PINGUIN_WIDTH)
            {
                x = screenWidth - Config.PINGUIN_WIDTH;
                MouvPinguin = StateMouvPinguin.FIX;
            }

            if (x < 0)
            {
                x = 0;
                MouvPinguin = StateMouvPinguin.FIX;
            }
        }

        public void GoLeft()
        {
            MouvPinguin = StateMouvPinguin.LEFT;
        }

        public void GoRight()
        {
            MouvPinguin = StateMouvPinguin.RIGHT;
        }

        public void Stop()
        {
            MouvPinguin = StateMouvPinguin.FIX;
        }

        public void Shoot()
        {
            shootPinguin = true;
            Stop();
        }

        public bool touched(EnemyProjectile projectile)
        {
            Rectangle player = new Rectangle((int)x + 45, y + 20, Config.PINGUIN_WIDTH - 90, Config.PINGUIN_HEIGHT - 30);

            return player.IntersectsWith(projectile.Bounds());
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            Image picture = _pinguinImage;

            if (shootPinguin)
            {
                picture = _pinguinShootImage;
            }

            else if (MouvPinguin == StateMouvPinguin.LEFT)
            {
                picture = _pinguinLeftImage;
            } 

            else if (MouvPinguin == StateMouvPinguin.RIGHT)
            {
                picture = _pinguinRightImage;
            }

            drawingSpace.Graphics.DrawImage(picture, x, y, Config.PINGUIN_WIDTH, Config.PINGUIN_HEIGHT);
        }
    }
}





