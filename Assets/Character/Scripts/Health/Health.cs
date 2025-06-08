using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool isDead;
    
    // Add player identification
    private PlayerMovement playerMovement;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>(); // Get player number
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!isDead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                isDead = true;
            }
        }
    }

    // Remove the test input or make it player-specific
    private void Update()
    {
        // Player 1: E key, Player 2: Period key for testing
        if (playerMovement != null)
        {
            if (playerMovement.playerNumber == 1 && Input.GetKeyDown(KeyCode.E))
            {
                TakeDamage(1);
                Debug.Log("Player 1 Health: " + currentHealth);
            }
            else if (playerMovement.playerNumber == 2 && Input.GetKeyDown(KeyCode.Period))
            {
                TakeDamage(1);
                Debug.Log("Player 2 Health: " + currentHealth);
            }
        }
    }
}