using UnityEngine.Assertions;
using ZombieGame.Entities;

namespace ZombieGame.Tests
{
    public class GameEntityTests
    {
        [Test]
        public void HealthStat_InitializesCorrectly()
        {
            GameEntity entity = new(
                new Core.Stat(100, 100),
                new Core.Stat(100, 100),
                new Core.Stat(100, 100),
                new Core.Stat(75, 75),
                new Core.Stat(100, 100),
                new Core.Stat(10, 10),
                100f, 100f, 100f);
            Assert.AreEqual(100, entity.Health.CurrentValue);
            Assert.AreEqual(100, entity.Health.MaxValue);
        }

        [Test]
        public void TakeDamage_ReducesHealth()
        {
            GameEntity entity = new(
                new Core.Stat(100, 100),
                new Core.Stat(100, 100),
                new Core.Stat(100, 100),
                new Core.Stat(75, 75),
                new Core.Stat(100, 100),
                new Core.Stat(10, 10),
                100f, 100f, 100f);
            entity.TakeDamage(10);
            Assert.AreEqual(90, entity.Health.CurrentValue);
        }
    }
}
