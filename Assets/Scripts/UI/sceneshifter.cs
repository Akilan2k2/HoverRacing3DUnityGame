using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneshifter : MonoBehaviour
{

    public GameObject Controlslayout;
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }


    public void Quit()
    {
        Application.Quit();   
    }


    public void controlsEnable()
    {
        Controlslayout.SetActive(true);
    }

    public void controlsDisable()
    {
        Controlslayout.SetActive(false);
    }
}
