namespace ShootMeUp
{
    public class HealthHelper
    {
        public int Lives { get; private set; } = 3;

        public void Reset()
        {
            Lives = 3;
        }

        public void loseLife()
        {
            if (Lives > 0)
            {
                Lives--;
            }
        }
    }
}
