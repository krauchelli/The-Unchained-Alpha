using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    // Make the damage value editable from the Inspector.
    [SerializeField] private float damage;

    // This function is called when another object enters this object's trigger collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered has the "Player" tag.
        if (collision.tag == "Player")
        {
            // If it's the player, get their Health component and call the TakeDamage function,
            // passing in the damage value from this script.
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}