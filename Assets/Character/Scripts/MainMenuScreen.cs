using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public GameObject objectToShow;

    public float displayDuration = 3f;

    public void startGame()
    {

        if (objectToShow != null)
        {
            objectToShow.SetActive(true);
        }

        Invoke("LoadSceneNow", displayDuration);
    }

    private void LoadSceneNow()
    {
        SceneManager.LoadScene("file1");
    }

    public void quitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}