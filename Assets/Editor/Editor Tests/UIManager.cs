using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Tooltip("The current state of the UI")]
    public string UIState;

    public void ChangeUIState(string newState)
    {
        // TODO: Implement the logic to change the UI state
        UIState = newState;
    }
}

public class UIManagerTest : MonoBehaviour
{
    [UnityTest]
    public IEnumerator UIManagerTestRoutine()
    {
        // Instantiate UI Manager
        GameObject go = new GameObject();
        UIManager uiManager = go.AddComponent<UIManager>();

        // Simulate UI interactions
        uiManager.ChangeUIState("NewState");

        yield return null;

        // Assert that the UI state has changed
        Assert.AreEqual("NewState", uiManager.UIState);
    }
}