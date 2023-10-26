using System;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public interface IDamageable
{
    void TakeDamage(int amount);
}

public interface IContainer
{
    void AddItem(Item item);
    void RemoveItem(Item item);
}

public interface ISaveState
{
    void SaveState();
    void LoadState();
}

public interface IUpgradable
{
    void Upgrade();
}

public interface IHasAI
{
    void Patrol();
    void Chase();
    void Attack();
}

public interface IUIElement
{
    void Show();
    void Hide();
}

public interface IQuest
{
    void StartQuest();
    void UpdateQuest();
    void CompleteQuest();
}

public interface ICombatant
{
    void InitiateAttack();
    void Defend();
    void Flee();
}

public interface IGather
{
    void Gather();
    void Store();
}

public interface IApplyProceduralRule
{
    void ApplyRule();
}

public interface IVoxel
{
    void Generate();
    void Destroy();
}

public interface IProcedural
{
    void GenerateTerrain();
    void GenerateEntities();
}

public interface IThreadSafe
{
    void Lock();
    void Unlock();
}

public interface IErrorHandle
{
    void LogError(string message);
    void HandleException(Exception ex);
}

public interface IGameObject
{
    void Instantiate(GameObject prefab);
    void Destroy(GameObject gameObject);
}

public interface IUnityComponent
{
    void AddComponent<T>(GameObject gameObject) where T : UnityEngine.Component;
    void RemoveComponent<T>(GameObject gameObject) where T : UnityEngine.Component;
}

public interface IConsumable
{
    void Consume();
}

public interface IDroppable
{
    void Drop();
}

public interface ICraftingIngredient
{
    void UseInCrafting();
}

public interface IManager
{
    void Initialize();
    void Shutdown();
}

public interface IMovable
{
    Vector3 CalculateNewPosition();
    void UpdatePosition(Vector3 newPosition);
}

public interface IAttackable
{
    void PerformAttack();
}

public interface IKillable
{
    void Die();
}

public interface ITestable
{
    void RunTests();
}

public interface IPanelManager
{
    void ShowPanel();
    void HidePanel();
    void SavePanel();
    void LoadPanel();
}

public interface ISQLiteDatabase
{
    void OpenConnection(string databasePath);
    void CloseConnection();
    List<Dictionary<string, object>> ExecuteQuery(string query);
}

public interface IRespawnable
{
    void Respawn();
}

public interface ICraftable
{
    Item Craft();
}

public interface IResource
{
    void Gather();
    int GetResourceAmount();
}