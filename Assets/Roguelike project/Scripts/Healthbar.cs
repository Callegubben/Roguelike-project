using UnityEngine;
using TMPro;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private RectTransform currentHealthBar;
    public PlayerStats playerStats;
    public TextMeshProUGUI healthbarText;
    private float maxWidth = 195;
    private float lastHP;

    private void Update()
    {
        if (playerStats.currentHealth != lastHP)
        {
            currentHealthBar.sizeDelta = new Vector2((maxWidth * (playerStats.currentHealth/playerStats.maxHealth)),currentHealthBar.sizeDelta.y);
        }
        lastHP = playerStats.currentHealth;
    }
}
