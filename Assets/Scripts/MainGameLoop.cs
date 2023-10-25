using UnityEngine;
using ZGEntities;
using ZGItems;
using ZGWorld;
using ZGCharacterCreation;
using System.Collections.Generic;
using ZGCore;

public class MainGameLoop : MonoBehaviour
{
    [Tooltip("Player entity")]
    public GameEntity player;

    [Tooltip("Player's inventory")]
    public List<BaseItem> playerInventory;

    void Start()
    {
        InitializePlayer();
        InitializeInventory();
    }

    // Initialize player with default stats
    void InitializePlayer()
    {
        Stat health = new Stat(100, 100);
        Stat hunger = new Stat(100, 100);
        Stat oxygen = new Stat(100, 100);
        Stat temperature = new Stat(98.6f, 100);
        Stat stamina = new Stat(100, 100);
        Stat speed = new Stat(5, 10);

        player = new GameEntity(health, hunger, oxygen, temperature, stamina, speed, 0, 0, 0);
    }

    // Initialize player's inventory with default items
    void InitializeInventory()
    {
        Dictionary<string, Stat> itemStats = new Dictionary<string, Stat>
        {
            { "HealthRestore", new Stat(25, 25) }
        };

        BaseItem healthPotion = new BaseItem("Health Potion", "Restores 25 health", itemStats);

        playerInventory = new List<BaseItem>
        {
            healthPotion
        };
    }

    // TODO: Implement player movement
    // TODO: Implement player interaction with the environment
    // TODO: Implement player's ability to use items from the inventory
    // TODO: Implement player's ability to pick up items and add them to the inventory
    // TODO: Implement player's ability to drop items from the inventory
    // TODO: Implement player's ability to equip items
    // TODO: Implement player's ability to unequip items
    // TODO: Implement player's ability to trade items with other entities
    // TODO: Implement player's ability to engage in combat with other entities
    // TODO: Implement player's ability to gain experience and level up
    // TODO: Implement player's ability to save and load game progress
}