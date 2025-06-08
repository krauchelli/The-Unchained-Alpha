using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [Header("Health References")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    [Header("Player Identification")]
    [SerializeField] private int playerNumber = 1; // 1 for Player 1, 2 for Player 2

    void Start()
    {
        if (playerHealth != null)
        {
            totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
        }
    }

    void Update()
    {
        if (playerHealth != null)
        {
            currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
        }
    }
}