using UnityEngine;

public class EndZone : MonoBehaviour
{
    [Header("End Zone Settings")]
    [SerializeField] private int targetPlayerNumber = 1; // Which player this end zone is for
    [SerializeField] private string playerTag = "Player";
    
    [Header("Visual Feedback")]
    [SerializeField] private GameObject completionEffect; // Optional particle effect
    [SerializeField] private Color completeColor = Color.green;
    [SerializeField] private Color incompleteColor = Color.red;
    
    private LevelComplete levelManager;
    private SpriteRenderer spriteRenderer;
    private bool playerInZone = false;
    
    private void Start()
    {
        // Find the LevelComplete manager in the scene
        levelManager = FindObjectOfType<LevelComplete>();
        if (levelManager == null)
        {
            Debug.LogError("No LevelComplete manager found in scene!");
        }
        
        // Get sprite renderer for visual feedback
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = incompleteColor;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null && playerMovement.playerNumber == targetPlayerNumber)
            {
                playerInZone = true;
                
                // Notify level manager
                if (levelManager != null)
                {
                    levelManager.SetPlayerComplete(targetPlayerNumber);
                }
                
                // Visual feedback
                UpdateVisuals(true);
                
                Debug.Log($"Player {targetPlayerNumber} entered their end zone!");
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null && playerMovement.playerNumber == targetPlayerNumber)
            {
                playerInZone = false;
                
                // Notify level manager
                if (levelManager != null)
                {
                    levelManager.SetPlayerIncomplete(targetPlayerNumber);
                }
                
                // Visual feedback
                UpdateVisuals(false);
                
                Debug.Log($"Player {targetPlayerNumber} left their end zone!");
            }
        }
    }
    
    private void UpdateVisuals(bool isComplete)
    {
        // Change color
        if (spriteRenderer != null)
        {
            spriteRenderer.color = isComplete ? completeColor : incompleteColor;
        }
        
        // Show/hide completion effect
        if (completionEffect != null)
        {
            completionEffect.SetActive(isComplete);
        }
    }
}