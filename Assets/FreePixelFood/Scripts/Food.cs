using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private FoodManager foodManager;

    private void Start()
    {
        foodManager = FoodManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            foodManager.ChangeFoodCount(value);
            Destroy(gameObject);
        }
    }
}
