using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenMenu : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private PlayerStats playerStats;

    private void OnEnable()
    {
        playerStats.PlayerWin();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
