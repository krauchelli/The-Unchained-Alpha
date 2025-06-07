using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; } // tujuannya adalah untuk mengakses currentHealth dari luar kelas ini, tapi tidak bisa mengubahnya dari luar kelas ini
    private Animator anim;
    private bool isDead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // player hurt
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!isDead)
            {
                anim.SetTrigger("die");
                // Disable the character controller or any other components that should not be active when dead
                GetComponent<PlayerMovement>().enabled = false; // Assuming you have a CharacterController2D component
                // player dead
                isDead = true;
            }
        }
    }

    //sample tes untuk mengurangi health
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
            Debug.Log("Current Health: " + currentHealth);
        }
    }
}
