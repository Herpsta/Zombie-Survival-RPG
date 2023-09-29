using UnityEngine.TestTools;
using ZombieGame.Items;
using ZombieGame.Tests;

public class ItemTests
    {
    [Test]
        public void ItemInitializationTest(System.Collections.Generic.Dictionary<string, ZombieGame.Core.Stat> dictionary)
        {
            // Arrange
            string name = "Test Item";
            string description = "This is a test item.";
            int id = 1;

        // Act
        Item item = new(name, description, ItemType.MeleeWeapon, dictionary);

            // Assert
            UnityEngine.Assertions.Assert.IsNotNull(item);
            UnityEngine.Assertions.Assert.AreEqual(name, item.Name);
            UnityEngine.Assertions.Assert.AreEqual(description, item.Description);
            UnityEngine.Assertions.Assert.AreEqual(id, item.Id);
        }
    }
