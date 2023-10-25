using System.Collections.Generic;

    public class BaseItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Stat> Stats { get; set; }

        public BaseItem(string name, string description, Dictionary<string, Stat> stats)
        {
            Name = name;
            Description = description;
            Stats = stats;
        }
    }

// TODO: Redo how items are managed in the code. Teehee.