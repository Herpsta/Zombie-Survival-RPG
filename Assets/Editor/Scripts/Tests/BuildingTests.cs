using ZombieGame.World;
using UnityEngine.TestTools;
using UnityEngine.Assertions;

namespace ZombieGame.Tests
{
    public class BuildingTests
    {
        [Test]
        public void BuildingInitializationTest()
        {
            Building building = new(BuildingType.Home);
            Assert.IsNotNull(building);
        }
    }
}
