using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private RectTransform maxHealthBar, currentHealthBar;
    public PlayerStats playerStats;
    public Text healthbarText;

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
