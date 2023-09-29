using ZombieGame.World;
using UnityEngine.TestTools;
using UnityEngine.Assertions;

namespace ZombieGame.Tests
{
    public class ContainerTests
    {
        [Test]
        public void ContainerInitializationTest()
        {
            Container container = new();
            Assert.IsNotNull(container);
        }
    }
}
