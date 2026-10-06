using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootMeUp
{
    internal static class Config
    {
        // Taille de l'écran
        public const int SCREEN_WIDTH = 1200;               // Largeur de l'écran 
        public const int SCREEN_HEIGHT = 600;               // Hauteur de l'écran 

        public const int SCREEN_MIN_WIDTH = 960;            // Largeur minimum de l'écran 
        public const int SCREEN_MIN_HEIGHT = 540;           // Hauteur minimum de l'écran

        public const int SCREEN_MAX_WIDTH = 1920;           // Largeur maximum de l'écran 
        public const int SCREEN_MAX_HEIGHT = 1080;          // Hauteur maximum de l'écran

        // Pinguin
        public const float SPEED = 220f;                    // Vitesse du pinguin

        public const int PINGUIN_WIDTH = 180;               // Largeur du pinguin
        public const int PINGUIN_HEIGHT = 140;              // Hauteur du pinguin

        // Boulle de neige 
        public const float SNOWBALL_SPEED = 5;              // Vitesse de la boulle de neige de 1 à 10 

        public const int SNOWBALL_WIDTH = 90;               // Largeur de la boulle de neige 
        public const int SNOWBALL_HEIGHT = 90;              // Hauteur de la boulle de neige 

        public const int SHOOT_TIME = 150;                  // Temps de tirs du personnage (ms)
        public const int SHOOT_COOLDOWN = 1000;             // Cooldown entre chaque tirs  (ms)
    }
}
