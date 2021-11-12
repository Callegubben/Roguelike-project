using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : Interactable
{
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private string nextScene;

    public override void Interact()
    {
        saveManager.SavePlayerData();
        SceneManager.LoadScene(nextScene);
    }
}
