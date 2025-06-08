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

        if (isActivated)
        {
            animator.SetTrigger("LeverOn");
            if (doorToToggle != null)
            {
                doorToToggle.Open();
            }
        }
        else
        {
            animator.SetTrigger("LeverOff");
            if (doorToToggle != null)
            {
                doorToToggle.Close();
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            // Check which player entered based on their PlayerMovement component
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                if (playerMovement.playerNumber == 1)
                {
                    player1IsNearby = true;
                }
                else if (playerMovement.playerNumber == 2)
                {
                    player2IsNearby = true;
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
                }
                else if (playerMovement.playerNumber == 2)
                {
                    player2IsNearby = false;
                }
            }
        }
    }
}