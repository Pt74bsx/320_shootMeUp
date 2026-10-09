using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootMeUp
{
    internal class SpaceManager
    {
        public static HomeSpace Home { get; private set; } = null!;

        public static CreditSpace Credit { get; private set; } = null!;

        public static GameSpace Game { get; private set; } = null!;

        // Initialise toutes les fenêtres
        public static void Initialize()
        {
            Home = new HomeSpace();
            Credit = new CreditSpace();
            Game = new GameSpace();

            Game.Activated += (sender, e) => Cursor.Hide();
            Game.Deactivate += (sender, e) => Cursor.Show();
        }
    }
}
