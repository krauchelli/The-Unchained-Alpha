using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; } // tujuannya adalah untuk mengakses currentHealth dari luar kelas ini, tapi tidak bisa mengubahnya dari luar kelas ini

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // player hurt
        }
        else
        {
            // player dead
        }
    }

    //sample tes untuk mengurangi health
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
            Debug.Log("Current Health: " + currentHealth);
        }
    }
}
