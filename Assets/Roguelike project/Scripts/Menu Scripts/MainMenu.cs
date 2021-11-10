using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private PlayerStats playerStats;

    public void StartGame()
    {
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
