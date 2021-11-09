using UnityEngine;
using TMPro;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private RectTransform maxHealthBar, currentHealthBar;
    public PlayerStats playerStats;
    public TextMeshProUGUI healthbarText;

    void Start()
    {
        currentHealthBar.sizeDelta = new Vector2(playerStats.currentHealth, 20);
        maxHealthBar.sizeDelta = new Vector2(playerStats.maxHealth+5, 25);
    }

    private void Update()
    {
        currentHealthBar.sizeDelta = new Vector2(playerStats.currentHealth, 20);
        maxHealthBar.sizeDelta = new Vector2(playerStats.maxHealth + 5, 25);
        healthbarText.text = $"{playerStats.currentHealth}/{playerStats.maxHealth}";
    }
}
