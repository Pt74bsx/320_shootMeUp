namespace ShootMeUp
{
    public class HealthHelper
    {
        public int Lives { get; private set; } = 3;
        public bool IsFinished { get; private set; }

        public void Reset()
        {
            Lives = 3;
            IsFinished = false;
        }

        public void loseLife()
        {
            if (Lives > 0)
            {
                Lives--;
            }

            if (Lives == 0)
            {
                IsFinished = true;
            }
        }

    }
}
