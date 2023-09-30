using System.Collections.Generic;
using ZGCore;

namespace ZGWorld
{   
    public class Building : Room
    {
        public BuildingType Type { get; set; }
        public List<Room> Rooms { get; set; }

        public Building(BuildingType bt) : base()
        {
            Type = bt;
            Rooms = new List<Room>();
        }
    }
}
