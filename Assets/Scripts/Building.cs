using System.Collections.Generic;

    public class Building : Room
    {
        public BuildingType Type { get; set; }
        public List<Room> Rooms { get; set; }

        public Building(BuildingType bt) : base()
        {
            Type = bt;
            Rooms = new List<Room>();
        }

        // TODO: Implement validation for room addition/removal if necessary

        // Method for adding a room
        public void AddRoom(Room room)
        {
            // Add the room to the list of rooms
            Rooms.Add(room);
        }

        // Method for removing a room
        public void RemoveRoom(Room room)
        {
            // Remove the room from the list of rooms
            Rooms.Remove(room);
        }
    }