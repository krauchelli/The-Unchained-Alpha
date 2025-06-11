using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] public string restartSceneName;
    public void setup()
    {
        gameObject.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(restartSceneName);
    }

    public void quitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
