using ZombieGame.Core;
using UnityEngine.Assertions;
using System;

namespace ZombieGame.Tests
{
    public class StatTests
    {
        [Test]
        public void Stat_InitializesCorrectly()
        {
            Stat stat = new(50, 100);
            Assert.AreEqual(50, stat.CurrentValue);
            Assert.AreEqual(100, stat.MaxValue);
        }
    }

    internal class TestAttribute : Attribute
    {
    }
}
