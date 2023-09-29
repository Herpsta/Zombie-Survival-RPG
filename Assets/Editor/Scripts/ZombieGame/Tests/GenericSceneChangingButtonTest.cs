using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEngine.Assertions;

namespace ZombieGame.Tests
{
    public class GenericSceneChangingButtonTest
    {
        [Test]
        public void SceneChangingButton_Clicked([Values("Scene1", "Scene2", "Scene3")] string targetScene)
        {
            // Arrange
            GameObject go = new GameObject();
            Button sceneChangingButton = go.AddComponent<Button>();
            string initialScene = SceneManager.GetActiveScene().name;

            // Act
            sceneChangingButton.onClick.AddListener(() => SceneManager.LoadScene(targetScene));
            sceneChangingButton.onClick.Invoke();
            string newScene = SceneManager.GetActiveScene().name;

            // Assert
            Assert.AreNotEqual(initialScene, newScene);
        }
    }
}