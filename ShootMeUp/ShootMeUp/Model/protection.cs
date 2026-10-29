using ShootMeUp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ShootMeUp.Pinguin;

namespace ShootMeUp
{
    public class Protection
    {
        private static readonly Image _protectionFull = ImageHelper.ResizeImage(Resources.protection_4, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
        private static readonly Image _protectionHigh = ImageHelper.ResizeImage(Resources.protection_3, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
        private static readonly Image _protectionMedium = ImageHelper.ResizeImage(Resources.protection_2, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
        private static readonly Image _protectionLow = ImageHelper.ResizeImage(Resources.protection_1, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
        private int x;
        private int y;

        public enum StateProtection { FULL, HIGH, MEDIUM, LOW }

        public StateProtection LevelProtection { get; private set; } = StateProtection.FULL;

        public Protection(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool touched(Snowball snowBall)
        {
            int margeBloc = 15;
            int margeBoule = 30;

            // IA : Calcule 
            if (snowBall.x + Config.SNOWBALL_WIDTH - margeBoule > x + margeBloc &&
                snowBall.x + margeBoule < x + Config.PROTECTION_WIDTH - margeBloc &&
                snowBall.y + Config.SNOWBALL_HEIGHT - margeBoule > y + margeBloc &&
                snowBall.y + margeBoule < y + Config.PROTECTION_HEIGHT - margeBloc)
            {
                return true;
            }

            return false;
        }

        public bool loseLife()
        {
            if (LevelProtection == StateProtection.FULL)
            {
                LevelProtection = StateProtection.HIGH;
            }

            else if (LevelProtection == StateProtection.HIGH)
            {
                LevelProtection = StateProtection.MEDIUM;
            }

            else if (LevelProtection == StateProtection.MEDIUM)
            {
                LevelProtection = StateProtection.LOW;
            }

            else if (LevelProtection == StateProtection.LOW)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Affichage de la protection selon son état 
        /// </summary>
        /// <param name="drawingSpace"></param>

        public void Render(BufferedGraphics drawingSpace)
        {
            if (LevelProtection == StateProtection.FULL)
            {
                drawingSpace.Graphics.DrawImage(_protectionFull, x, y, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
            }
            else if (LevelProtection == StateProtection.HIGH)
            {
                drawingSpace.Graphics.DrawImage(_protectionHigh, x, y, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
            }
            else if (LevelProtection == StateProtection.MEDIUM)
            {
                drawingSpace.Graphics.DrawImage(_protectionMedium, x, y, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
            }
            else if (LevelProtection == StateProtection.LOW)
            {
                drawingSpace.Graphics.DrawImage(_protectionLow, x, y, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
            }
        }
    }
}
