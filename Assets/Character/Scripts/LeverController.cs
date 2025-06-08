using UnityEngine;

public class LeverController : MonoBehaviour
{
    [Header("Control Settings")]
    // In the Inspector, drag the SpearDoor object you want this lever to control
    [SerializeField] private SpearDoor doorToToggle; 

    [Header("Player Interaction")]
    [SerializeField] private KeyCode interactKey = KeyCode.F;
    [SerializeField] private string playerTag = "Player";

    // Internal components and state
    private Animator animator;
    private bool playerIsNearby = false;
    private bool isActivated = false; // Tracks the state: false = Off/Closed, true = On/Open

    void Awake()
    {
        // Get the Animator component that is on this same Lever object
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        // Checks every frame if the player is in range and presses the interact key
        if (playerIsNearby && Input.GetKeyDown(interactKey))
        {
            ToggleLever();
        }
    }

    /// <summary>
    /// This is the main logic function. It flips the lever's state and controls
    /// both its own animation and the door's state.
    /// </summary>
    private void ToggleLever()
    {
        // Invert the activation state (if it was off, it becomes on, and vice-versa)
        isActivated = !isActivated;

        if (isActivated)
        {
            // --- STATE: LEVER IS NOW ON ---
            
            // 1. Play the lever's "On" animation
            animator.SetTrigger("LeverOn");
            
            // 2. Tell the assigned SpearDoor to open
            if (doorToToggle != null)
            {
                doorToToggle.Open();
            }
        }
        else
        {
            // --- STATE: LEVER IS NOW OFF ---

            // 1. Play the lever's "Off" animation
            animator.SetTrigger("LeverOff");

            // 2. Tell the assigned SpearDoor to close
            if (doorToToggle != null)
            {
                doorToToggle.Close();
            }
        }
    }
    
    // This function runs when a player enters the lever's BoxCollider2D trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            playerIsNearby = true;
        }
    }
    
    // This function runs when the player leaves the trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            playerIsNearby = false;
        }
    }
}
