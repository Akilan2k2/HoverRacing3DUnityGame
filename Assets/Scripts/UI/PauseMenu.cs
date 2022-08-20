using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public  bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    private void Start()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }


    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            
            }
      }
    
    }

    public void Resume()
        {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        }


    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void gotoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }


}
