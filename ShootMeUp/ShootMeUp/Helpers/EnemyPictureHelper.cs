using ShootMeUp.Properties;

namespace ShootMeUp
{
    internal static class EnemyPictureHelper
    {
        // IA : préparer les images et choisir la pose
        private static readonly Image _golemShoot = PictureHelper.ResizeImage(Resources.golem_tir, 80, 128);
        private static readonly Image _golemLeft = PictureHelper.ResizeImage(Resources.golem_gauche, 80, 128);
        private static readonly Image _golemRight = PictureHelper.ResizeImage(Resources.golem_droite, 80, 128);
        private static readonly Image _golemUp = PictureHelper.ResizeImage(Resources.golem_haut, 80, 128);
        private static readonly Image _golemDown = PictureHelper.ResizeImage(Resources.golem_bas, 80, 128);
        private static readonly Image _golemRest1 = PictureHelper.ResizeImage(Resources.golem_repos_1, 80, 128);
        private static readonly Image _golemRest2 = PictureHelper.ResizeImage(Resources.golem_repos_2, 80, 128);

        private static readonly Image _morseShoot = PictureHelper.ResizeImage(Resources.morse_tir, 80, 122);
        private static readonly Image _morseLeft = PictureHelper.ResizeImage(Resources.morse_gauche, 80, 122);
        private static readonly Image _morseRight = PictureHelper.ResizeImage(Resources.morse_droite, 80, 122);
        private static readonly Image _morseUp = PictureHelper.ResizeImage(Resources.morse_haut, 80, 122);
        private static readonly Image _morseDown = PictureHelper.ResizeImage(Resources.morse_bas, 80, 122);
        private static readonly Image _morseRest1 = PictureHelper.ResizeImage(Resources.morse_repos_1, 80, 122);
        private static readonly Image _morseRest2 = PictureHelper.ResizeImage(Resources.morse_repos_2, 80, 122);

        private static readonly Image _hibouShoot = PictureHelper.ResizeImage(Resources.hibou_tir, 80, 130);
        private static readonly Image _hibouLeft = PictureHelper.ResizeImage(Resources.hibou_gauche, 80, 130);
        private static readonly Image _hibouRight = PictureHelper.ResizeImage(Resources.hibou_droite, 80, 130);
        private static readonly Image _hibouUp = PictureHelper.ResizeImage(Resources.hibou_haut, 80, 130);
        private static readonly Image _hibouDown = PictureHelper.ResizeImage(Resources.hibou_bas, 80, 130);
        private static readonly Image _hibouRest1 = PictureHelper.ResizeImage(Resources.hibou_repos_1, 80, 130);
        private static readonly Image _hibouRest2 = PictureHelper.ResizeImage(Resources.hibou_repos_2, 80, 130);

        private static readonly Image _golemProjectile = PictureHelper.ResizeImage(Resources.golem_projectile, 44, 58);
        private static readonly Image _morseProjectile = PictureHelper.ResizeImage(Resources.morse_projectile, 34, 67);
        private static readonly Image _hibouProjectile = PictureHelper.ResizeImage(Resources.hibou_projectile, 25, 33);

        public static Image GetImage(Enemy enemy)
        {
            if (enemy.Type == 0)
            {
                return GetGolemImage(enemy);
            }
            if (enemy.Type == 1)
            {
                return GetMorseImage(enemy);
            }
            return GetHibouImage(enemy);
        }

        private static Image GetGolemImage(Enemy enemy)
        {
            if (enemy.ShootTime > 0)
            {
                return _golemShoot;
            }
            if (enemy.IsMoving)
            {
                if (enemy.Direction == 0)
                {
                    return _golemLeft;
                }
                if (enemy.Direction == 1)
                {
                    return _golemRight;
                }
                if (enemy.Direction == 2)
                {
                    return _golemUp;
                }
                return _golemDown;
            }
            if (enemy.AnimationTime < 0.5f)
            {
                return _golemRest1;
            }
            return _golemRest2;
        }

        private static Image GetMorseImage(Enemy enemy)
        {
            if (enemy.ShootTime > 0)
            {
                return _morseShoot;
            }
            if (enemy.IsMoving)
            {
                if (enemy.Direction == 0)
                {
                    return _morseLeft;
                }
                if (enemy.Direction == 1)
                {
                    return _morseRight;
                }
                if (enemy.Direction == 2)
                {
                    return _morseUp;
                }
                return _morseDown;
            }
            if (enemy.AnimationTime < 0.5f)
            {
                return _morseRest1;
            }
            return _morseRest2;
        }

        private static Image GetHibouImage(Enemy enemy)
        {
            if (enemy.ShootTime > 0)
            {
                return _hibouShoot;
            }
            if (enemy.IsMoving)
            {
                if (enemy.Direction == 0)
                {
                    return _hibouLeft;
                }
                if (enemy.Direction == 1)
                {
                    return _hibouRight;
                }
                if (enemy.Direction == 2)
                {
                    return _hibouUp;
                }
                return _hibouDown;
            }
            if (enemy.AnimationTime < 0.5f)
            {
                return _hibouRest1;
            }
            return _hibouRest2;
        }

        public static Image GetProjectileImage(int type)
        {
            if (type == 0)
            {
                return _golemProjectile;
            }
            if (type == 1)
            {
                return _morseProjectile;
            }
            return _hibouProjectile;
        }
    }
}
