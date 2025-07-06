using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private GameObject endingStory;
    [SerializeField] private GameObject VictoryScreen;

    [Header("Player Completion")]
    [SerializeField] private bool player1Complete = false;
    [SerializeField] private bool player2Complete = false;

    [Header("Debug")]
    [SerializeField] private bool showDebugLogs = true;
    private bool levelCompleted = false;
    public PlayerMovement player1;
    public PlayerMovement player2;

    private void Update()
    {
        // Check if both players have completed the level
        if (!levelCompleted && player1Complete && player2Complete)
        {
            levelCompleted = true;
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
        player1.enabled = false;
        player2.enabled = false;

        ShowEndingStory();
        Invoke("ShowVictoryScreen", 3f);
    }

    private void ShowVictoryScreen()
    {
        if (VictoryScreen != null)
        {
            endingStory.SetActive(false);
            VictoryScreen.SetActive(true);
        }
    }

    private void ShowEndingStory()
    {
        if (endingStory != null)
        {
            endingStory.SetActive(true);
        }
    }

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