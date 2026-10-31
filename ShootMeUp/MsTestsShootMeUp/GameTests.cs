namespace MsTestsShootMeUp
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void testScore()
        {
            ShootMeUp.ScoreHelper score = new ShootMeUp.ScoreHelper();

            score.AddScore(10);

            Assert.AreEqual(10, score.Points);
        }

        [TestMethod]
        public void testVie()
        {
            ShootMeUp.HealthHelper health = new ShootMeUp.HealthHelper();

            health.loseLife();
            health.loseLife();
            health.loseLife();

            Assert.AreEqual(0, health.Lives);
            Assert.IsTrue(health.IsFinished);
        }

        [TestMethod]
        public void testEnnemis()
        {
            ShootMeUp.EnemyHelper enemies = new ShootMeUp.EnemyHelper();

            enemies.Reset();

            Assert.AreEqual(5, enemies.Enemies.Count);
        }

        [TestMethod]
        public void testResetScore()
        {
            ShootMeUp.ScoreHelper score = new ShootMeUp.ScoreHelper();
            score.AddScore(20);

            score.Reset();

            Assert.AreEqual(0, score.Points);
        }

        [TestMethod]
        public void testResetVie()
        {
            ShootMeUp.HealthHelper health = new ShootMeUp.HealthHelper();
            health.loseLife();
            health.loseLife();
            health.loseLife();

            health.Reset();

            Assert.AreEqual(3, health.Lives);
            Assert.IsFalse(health.IsFinished);
        }

        [TestMethod]
        public void testTirEnnemi()
        {
            ShootMeUp.EnemyHelper enemies = new ShootMeUp.EnemyHelper();
            ShootMeUp.Enemy enemy = new ShootMeUp.Enemy(0, 0);
            enemy.ShootCooldown = 1;
            enemy.MoveTime = 10;
            enemies.Enemies.Add(enemy);
            ShootMeUp.Pinguin player = new ShootMeUp.Pinguin(100, 400);

            enemies.Update(0.5f, 1200, 600, player);

            Assert.AreEqual(0f, enemy.ShootTime);
            Assert.AreEqual(0, enemies.Projectiles.Count);

            enemies.Update(0.5f, 1200, 600, player);

            Assert.IsTrue(enemy.ShootTime > 0);
        }

    }
}
