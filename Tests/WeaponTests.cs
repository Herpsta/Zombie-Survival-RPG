using ZombieGame.Core;
using ZombieGame.Items;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace ZombieGame.Tests
{
    public class WeaponItemTests
    {
        [Test]
        public void WeaponItem_InitializesCorrectly()
        {
            Dictionary<string, Stat> stats = new Dictionary<string, Stat>();
            WeaponItem weapon = new("Test Weapon", "A test weapon", stats);
            Assert.AreEqual("Test Weapon", weapon.Name);
        }
    }
}