namespace ShootMeUp
{
    internal static class PictureHelper
    {
        // IA : préparer une image à sa taille de dessin 
        public static Image ResizeImage(Image picture, int width, int height)
        {
            return new Bitmap(picture, width, height);
        }
    }
}
