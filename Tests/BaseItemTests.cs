using UnityEngine.TestTools;
using System.Collections;
using ZombieGame.Items;
using System.Collections.Generic;
using ZombieGame.Core;
using UnityEngine.Assertions;

namespace ZombieGame.Tests
{
    public class BaseItemTests
    {
        [Test]
        public IEnumerator BaseItem_InitializesCorrectly()
        {
            Dictionary<string, Stat> stats = new Dictionary<string, Stat>();
            BaseItem item = new("Test Item", "A test item", stats);
            Assert.AreEqual("Test Item", item.Name);
            yield return null;
        }
    }
}