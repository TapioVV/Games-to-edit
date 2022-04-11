using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject shooter;
    public GameObject pauseScreen;

    public bool isPaused;

    void Update()
    {
        PauseGame();
        exit();
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if(isPaused == true)
        {
            pauseGame();
            shooter.SetActive(false);
            pauseScreen.SetActive(true);
        }
        if (isPaused == false)
        {
            Time.timeScale = 1;
            shooter.SetActive(true);
            pauseScreen.SetActive(false);
        }
    }

    void pauseGame()
    {
        Time.timeScale = 0;
    }
    void exitWhenPaused()
    {        
            SceneManager.LoadScene("StartScreen");
    }
    void exit()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) == true && isPaused)
        {
            exitWhenPaused();
        }
    }

}
