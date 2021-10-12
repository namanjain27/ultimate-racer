using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    public bool gameISpaused = false;

    public GameObject pause_canvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameISpaused)
            {
                resume();
            }
            else pause();
        }
        
    }

    

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void resume()
    {
        gameISpaused = false;
        pause_canvas.SetActive(false);
        Time.timeScale = 1f;
    }

    private void pause()
    {
        pause_canvas.SetActive(true);
        gameISpaused = true;
        Time.timeScale = 0f;
    }

    public void load_menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void quit_game()
    {
        Application.Quit();
    }
}
