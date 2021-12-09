using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image currentHealthBar;
    public PlayerStats playerStats;
    public TextMeshProUGUI healthbarText;
    private float lastHP;

    private void Update()
    {
        if (playerStats.currentHealth != lastHP)
        {
            currentHealthBar.fillAmount = playerStats.currentHealth / playerStats.maxHealth;
        }
        lastHP = playerStats.currentHealth;
    }
}
