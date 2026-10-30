namespace ShootMeUp
{
    public class ScoreHelper
    {
        public int Points { get; private set; }

        public void Reset()
        {
            Points = 0;
        }

        public void AddScore(int points)
        {
            if (points > 0)
            {
                Points += points;
            }
        }
    }
}
