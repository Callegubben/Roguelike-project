using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private PlayerStats playerStats;

    public void StartGame()
    {
        if (playerStats.currentScene.Equals(string.Empty))
        {
            playerStats.currentScene = "Hub";
        }
        try
        {
            SceneManager.LoadScene(playerStats.currentScene);
        }
        catch (NullReferenceException)
        {
            SceneManager.LoadScene("Hub");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
