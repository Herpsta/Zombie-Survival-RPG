using UnityEngine.Assertions;
using ZombieGame.World;

namespace ZombieGame.Tests
{
    public class RoomTests
    {
        [Test]
        public void RoomInitializationTest()
        {
            Room room = new();
            Assert.IsNotNull(room);
        }
    }
}
