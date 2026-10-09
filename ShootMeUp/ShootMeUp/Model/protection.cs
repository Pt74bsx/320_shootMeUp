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

        

        /// <summary>
        /// Affichage de la protection selon son état 
        /// </summary>
        /// <param name="drawingSpace"></param>
        public void Render(BufferedGraphics drawingSpace)
        {
            if (LevelProtection == StateProtection.FULL)
            {
                drawingSpace.Graphics.DrawImage(Resources.protection_4, x, y, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
            }
            else if (LevelProtection == StateProtection.HIGH)
            {
                drawingSpace.Graphics.DrawImage(Resources.protection_3, x, y, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
            }
            else if (LevelProtection == StateProtection.MEDIUM)
            {
                drawingSpace.Graphics.DrawImage(Resources.protection_2, x, y, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
            }
            else if (LevelProtection == StateProtection.LOW)
            {
                drawingSpace.Graphics.DrawImage(Resources.protection_1, x, y, Config.PROTECTION_WIDTH, Config.PROTECTION_HEIGHT);
            }
        }
    }
}
