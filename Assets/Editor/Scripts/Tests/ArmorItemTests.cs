using UnityEngine.TestTools;
using System.Collections;
using ZombieGame.Items;
using System.Collections.Generic;
using ZombieGame.Core;
using UnityEngine.Assertions;

namespace ZombieGame.Tests
{
    public class ArmorItemTests
    {
        [Test]
        public IEnumerator ArmorItem_InitializesCorrectly()
        {
            Dictionary<string, Stat> stats = new Dictionary<string, Stat>();
            ArmorItem armor = new("Test Armor", "A test armor", stats);
            Assert.AreEqual("Test Armor", armor.Name);
            yield return null;
        }
    }
}