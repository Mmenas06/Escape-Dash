using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenu;
    private bool isPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void OnResumeClick()
    {
        isPaused = false;
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
