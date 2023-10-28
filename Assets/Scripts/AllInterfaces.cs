using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

// SOLID Principles and Design Patterns are applied across these interfaces.

// Interface for Singleton pattern.
public interface ISingleton
{
    void Initialize();  // Single-Responsibility Principle
}

// Interface for Observer pattern.
public interface IObserver
{
    void OnNotify(Event eventData);  // Open-Closed Principle
}

// Interface for Factory pattern.
public interface IFactory<T>
{
    T Create();  // Liskov Substitution Principle
}

// Interface for State pattern.
public interface IState
{
    void Enter();  // Interface Segregation Principle
    void Execute();
    void Exit();
}

// Interface for Dependency Injection.
public interface IDependencyInjector
{
    T GetDependency<T>();  // Dependency Inversion Principle
}

// Interface for manager classes, adhering to the Singleton pattern.
public interface IManager : ISingleton
{
    void Initialize();
    void Shutdown();
}

// Interface for options management, adhering to the Dependency Injection pattern.
public interface IOptionsManager : IDependencyInjector
{
    void RegisterPanel(IPanelManager panelManager);
    void ShowOnlyThisPanel(IPanelManager activePanel);
    void Save();
    void Load();
    void ShowAllPanels();
    void HideAllPanels();
}

// Interface for settings, adhering to the Data-Driven approach.
public interface ISettings
{
    SimpleSQLManager DbManager { get; set; }
    Task Start();
    void SaveSettings();
}

// Interface for graphics settings.
public interface IGraphicsSettings
{
    int ResolutionIndex { get; set; }
    bool FullScreen { get; set; }
}

// Interface for accessibility settings.
public interface IAccessibilitySettings
{
    bool Subtitles { get; set; }
    bool IsColorblindMode { get; set; }
    bool IsHighContrastMode { get; set; }
    bool IsTextToSpeech { get; set; }
    bool IsVoiceCommands { get; set; }
    int FontSize { get; set; }
    int AspectRatio { get; set; }
}

// Interface for sound settings.
public interface ISoundSettings
{
    float MasterVolume { get; set; }
}

// Interface for controls settings.
public interface IControlsSettings
{
    KeyCode JumpKey { get; set; }
}

// Interface for gameplay settings.
public interface IGameplaySettings
{
    int DifficultyLevel { get; set; }
}

// ... (Other interfaces can be extended in a similar fashion)
// ... (Continuing from IGameplaySettings)

// Interface for objects that can be interacted with.
public interface IInteractable
{
    void Interact();  // Single-Responsibility Principle
}

// Interface for objects that can take damage.
public interface IDamageable
{
    void TakeDamage(int amount);  // Open-Closed Principle
}

// Interface for container objects like inventory.
public interface IContainer
{
    void AddItem(Item item);  // Liskov Substitution Principle
    void RemoveItem(Item item);
}

// Interface for saving and loading states.
public interface ISaveState
{
    void SaveState();  // Interface Segregation Principle
    void LoadState();
}

// Interface for objects that can be upgraded.
public interface IUpgradable
{
    void Upgrade();  // Dependency Inversion Principle
}

// Interface for objects with AI behaviors.
public interface IHasAI
{
    void Patrol();
    void Chase();
    void Attack();
}

// Interface for UI elements.
public interface IUIElement
{
    void Show();
    void Hide();
}

// Interface for quest-related functionalities.
public interface IQuest
{
    void StartQuest();
    void UpdateQuest();
    void CompleteQuest();
}

// Interface for combat actions.
public interface ICombatant
{
    void InitiateAttack();
    void Defend();
    void Flee();
}

// Interface for gathering resources.
public interface IGather
{
    void Gather();
    void Store();
}

// Interface for applying procedural rules.
public interface IApplyProceduralRule
{
    void ApplyRule();
}

// Interface for voxel functionalities.
public interface IVoxel
{
    void Generate();
    void Destroy();
}

// Interface for procedural generation.
public interface IProcedural
{
    void GenerateTerrain();
    void GenerateEntities();
}

// Interface for thread-safe operations.
public interface IThreadSafe
{
    void Lock();
    void Unlock();
}

// Interface for error handling.
public interface IErrorHandle
{
    void LogError(string message);
    void HandleException(Exception ex);
}

// Interface for GameObject operations.
public interface IGameObject
{
    void Instantiate(GameObject prefab);
    void Destroy(GameObject gameObject);
}

// Interface for Unity Component operations.
public interface IUnityComponent
{
    void AddComponent<T>(GameObject gameObject) where T : UnityEngine.Component;
    void RemoveComponent<T>(GameObject gameObject) where T : UnityEngine.Component;
}

// Interface for consumable objects.
public interface IConsumable
{
    void Consume();
}

// Interface for droppable objects.
public interface IDroppable
{
    void Drop();
}

// Interface for crafting ingredients.
public interface ICraftingIngredient
{
    void UseInCrafting();
}

// Interface for respawnable objects.
public interface IRespawnable
{
    void Respawn();
}

// Interface for craftable objects.
public interface ICraftable
{
    Item Craft();
}

// Interface for resource gathering.
public interface IResource
{
    void Gather();
    int GetResourceAmount();
}

// Interface for testable objects.
public interface ITestable
{
    void RunTests();
}

// Interface for panel management.
public interface IPanelManager
{
    void ShowPanel();
    void HidePanel();
    void Save();
    void Load();
}

// Interface for SQLite database operations.
public interface ISQLiteDatabase
{
    void OpenConnection(string databasePath);
    void CloseConnection();
    List<Dictionary<string, object>> ExecuteQuery(string query);
}

// Interface for movable objects.
public interface IMovable
{
    Vector3 CalculateNewPosition();
    void UpdatePosition(Vector3 newPosition);
}

// Interface for attackable objects.
public interface IAttackable
{
    void PerformAttack();
}

// Interface for killable objects.
public interface IKillable
{
    void Die();
}

public interface IWeapon
{
    void PrimaryAction();  // For attacking, shooting, etc.
    void SecondaryAction();  // For kicking, zooming in, etc.
    void Block();  // For blocking
    void Reload();  // For reloading
    void PowerAttack();  // For power attacks
}
