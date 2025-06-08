using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private string nextSceneName = "NextLevel";
    [SerializeField] private int nextSceneIndex = -1; // Use -1 to use scene name instead
    
    [Header("Player Completion")]
    [SerializeField] private bool player1Complete = false;
    [SerializeField] private bool player2Complete = false;
    
    [Header("Debug")]
    [SerializeField] private bool showDebugLogs = true;
    
    private void Update()
    {
        // Check if both players have completed the level
        if (player1Complete && player2Complete)
        {
            CompleteLevel();
        }
    }
    
    public void SetPlayerComplete(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Complete = true;
            if (showDebugLogs) Debug.Log("Player 1 reached the end!");
        }
        else if (playerNumber == 2)
        {
            player2Complete = true;
            if (showDebugLogs) Debug.Log("Player 2 reached the end!");
        }
        
        if (showDebugLogs) 
        {
            Debug.Log($"Level Progress - P1: {player1Complete}, P2: {player2Complete}");
        }
    }
    
    public void SetPlayerIncomplete(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Complete = false;
            if (showDebugLogs) Debug.Log("Player 1 left the end zone!");
        }
        else if (playerNumber == 2)
        {
            player2Complete = false;
            if (showDebugLogs) Debug.Log("Player 2 left the end zone!");
        }
    }
    
    private void CompleteLevel()
    {
        if (showDebugLogs) Debug.Log("Both players completed! Loading next level...");
        
        // Add a small delay before loading next scene (optional)
        Invoke("LoadNextLevel", 1f);
    }
    
    private void LoadNextLevel()
    {
        if (nextSceneIndex >= 0)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("No next scene specified!");
        }
    }
    
    // Public methods for external access
    public bool IsLevelComplete()
    {
        return player1Complete && player2Complete;
    }
    
    public bool IsPlayer1Complete()
    {
        return player1Complete;
    }
    
    public bool IsPlayer2Complete()
    {
        return player2Complete;
    }
}