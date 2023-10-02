using UnityEngine;
using ZGEntities;
using ZGItems;
using ZGWorld;
using ZGCharacterCreation;
using System.Collections.Generic;
using ZGCore;

public class MainGameLoop : MonoBehaviour
{
    public GameEntity player;

    void Start()
    {
        InitializePlayer();
        InitializeInventory();
        InitializeUI();
    }

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

    public List<BaseItem> playerInventory;

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
    public UIManager uiManager;

    void InitializeUI()
    {
        uiManager.UpdateHealthBar(player.Health.CurrentValue);
    }


}
