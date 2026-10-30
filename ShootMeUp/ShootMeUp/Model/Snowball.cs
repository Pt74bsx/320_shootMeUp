using ShootMeUp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShootMeUp.Pinguin;

namespace ShootMeUp
{
    public class Snowball
    {
        private static readonly Image _snowballImage = PictureHelper.ResizeImage(Resources.snowball, Config.SNOWBALL_WIDTH, Config.SNOWBALL_HEIGHT);

        public float x;
        public float y;

        public Snowball(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void Update(float elapsedTime)
        {
            y -= Config.SNOWBALL_SPEED * 100 * elapsedTime;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            //float ratio = y / Config.SCREEN_HEIGHT;
            drawingSpace.Graphics.DrawImage(_snowballImage, x, y, Config.SNOWBALL_WIDTH /** ratio*/, Config.SNOWBALL_HEIGHT /** ratio*/);
        }
    }
}




