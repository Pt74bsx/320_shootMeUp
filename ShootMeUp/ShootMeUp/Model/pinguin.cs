using ShootMeUp.Properties;
using System.Drawing;

namespace ShootMeUp
{
    public class Pinguin
    {
        public const int PINGUIN_WIDTH = 180;
        public const int PINGUIN_HEIGHT = 140;

        public enum StateMouvPinguin { LEFT, FIX, RIGHT }

        public float x;
        public int y;

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

            if (x > screenWidth - PINGUIN_WIDTH)
            {
                x = screenWidth - PINGUIN_WIDTH;
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

        public void Render(BufferedGraphics drawingSpace)
        {
            Image picture = Resources.pinguin;

            if (MouvPinguin == StateMouvPinguin.LEFT)
            {
                picture = Resources.pinguinLeft;
            } 
            else if (MouvPinguin == StateMouvPinguin.RIGHT)
            {
                picture = Resources.pinguinRight;
            }

            drawingSpace.Graphics.DrawImage(picture, x, y, PINGUIN_WIDTH, PINGUIN_HEIGHT);
        }
    }
}
