using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : Interactable
{
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private string nextScene;
    [SerializeField] private Checkpoint target;

    public override void Interact()
    {
        saveManager.SavePlayerData();
        SceneManager.LoadScene(nextScene);
    }
}
