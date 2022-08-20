using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour
{

    IEnumerator Start()
    {
        yield return StartCoroutine(WaitAndLoad(5.0f));
        SceneManager.LoadScene("Level1");

    }

    // suspend execution for waitTime seconds
    IEnumerator WaitAndLoad(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

    }
}
