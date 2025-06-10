using UnityEngine;

public class LeverController : MonoBehaviour
{
    [Header("Control Settings")]
    [SerializeField] private SpearDoor doorToToggle; 

    [Header("Player Interaction")]
    [SerializeField] private string playerTag = "Player";

    // Internal components and state
    private Animator animator;
    private bool player1IsNearby = false;
    private bool player2IsNearby = false;
    private bool isActivated = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        
        // Add null checks
        if (animator == null)
        {
            Debug.LogError($"No Animator component found on {gameObject.name}! Lever requires an Animator component.", this);
        }
        
        if (doorToToggle == null)
        {
            Debug.LogWarning($"No door assigned to {gameObject.name}! Please assign a SpearDoor in the inspector.", this);
        }
    }
    
    void Update()
    {
        // Check for Player 1 interaction (F key)
        if (player1IsNearby && Input.GetKeyDown(KeyCode.F))
        {
            ToggleLever();
        }
        
        // Check for Player 2 interaction (/ key)
        if (player2IsNearby && Input.GetKeyDown(KeyCode.Slash))
        {
            ToggleLever();
        }
    }

    private void ToggleLever()
    {
        isActivated = !isActivated;
        Debug.Log($"Lever {gameObject.name} toggled. Activated: {isActivated}");

        if (animator != null)
        {
            if (isActivated)
            {
                animator.SetTrigger("LeverOn");
            }
            else
            {
                animator.SetTrigger("LeverOff");
            }
        }

        if (doorToToggle != null)
        {
            if (isActivated)
            {
                doorToToggle.Open();
            }
            else
            {
                doorToToggle.Close();
            }
        }
        else
        {
            Debug.LogWarning($"No door assigned to lever {gameObject.name}!");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                if (playerMovement.playerNumber == 1)
                {
                    player1IsNearby = true;
                    Debug.Log($"Player 1 near lever {gameObject.name}");
                }
                else if (playerMovement.playerNumber == 2)
                {
                    player2IsNearby = true;
                    Debug.Log($"Player 2 near lever {gameObject.name}");
                }
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                if (playerMovement.playerNumber == 1)
                {
                    player1IsNearby = false;
                    Debug.Log($"Player 1 left lever {gameObject.name}");
                }
                else if (playerMovement.playerNumber == 2)
                {
                    player2IsNearby = false;
                    Debug.Log($"Player 2 left lever {gameObject.name}");
                }
            }
        }
    }
}