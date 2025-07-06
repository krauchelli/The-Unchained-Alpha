using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    public GameOverScreen gameOverScreen;
    public PlayerMovement secondPlayerMovement;
    private Animator anim;
    private bool isDead;

    // Add player identification
    private PlayerMovement playerMovement;
    private FoodManager foodManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>(); // Get player number
        foodManager = FoodManager.instance;
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
                if (secondPlayerMovement != null)
                {
                    secondPlayerMovement.enabled = false;
                }
                isDead = true;
                gameOverScreen.setup();
            }
        }
    }

    public void AddHealth(float _amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + _amount, 0, startingHealth);
    }

    private void Update()
    {
        if (playerMovement == null) return;

        if (playerMovement.playerNumber == 1 && Input.GetKeyDown(KeyCode.E))
        {
            if (foodManager.FoodCount > 0 && currentHealth < startingHealth)
            {
                AddHealth(1);
                foodManager.ChangeFoodCount(-1);
                Debug.Log("Player 1 menggunakan food. Darah saat ini: " + currentHealth);
            }
        }
        else if (playerMovement.playerNumber == 2 && Input.GetKeyDown(KeyCode.Period))
        {
            if (foodManager.FoodCount > 0 && currentHealth < startingHealth)
            {
                AddHealth(1);
                foodManager.ChangeFoodCount(-1);
                Debug.Log("Player 2 menggunakan food. Darah saat ini: " + currentHealth);
            }
        }
    }
}