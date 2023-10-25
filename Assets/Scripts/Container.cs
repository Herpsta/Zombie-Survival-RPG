using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [Tooltip("List of items in the container")]
    public List<BaseItem> Items;

    [Tooltip("Chance for the container to contain an item")]
    [Range(0, 1)]
    public float ChanceToContainItem;

    public Container()
    {
        Items = new List<BaseItem>();
        ChanceToContainItem = 0.5f;  // 50% chance by default
    }

    public void AddItem(BaseItem item)
    {
        Items.Add(item);
    }

    public BaseItem RemoveItem(BaseItem item)
    {
        Items.Remove(item);
        return item;
    }

    // TODO: Implement a method to populate the container based on ChanceToContainItem.
    public void PopulateContainer(BaseItem item)
    {
        // Generate a random number between 0 and 1
        float randomChance = UnityEngine.Random.Range(0f, 1f);

        // If the random number is less than or equal to ChanceToContainItem, add the item to the container
        if (randomChance <= ChanceToContainItem)
        {
            AddItem(item);
        }
    }
}