using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RVP;
public class Countdown : MonoBehaviour
{
    public Text CountDowntext;
    void Start()
    {
        StartCoroutine(Countdowntimer(3));


        FollowAI[] followai = FindObjectsOfType<FollowAI>();
        foreach(FollowAI v in followai)
        {
            v.enabled = false;
        }
 
        BasicInput basicInput = FindObjectOfType<BasicInput>();


        basicInput.enabled = false;
    
    }

    IEnumerator Countdowntimer(int seconds)
    {
        int count = seconds;
       
        while (count > 0)
        {
            
            // display something...
            yield return new WaitForSeconds(1);
            count--;
            CountDowntext.text = count.ToString();
        }

        // count down is finished...
        StartGame();
    }

    void StartGame()
    {
        CountDowntext.text = "";
        BasicInput basicInput = FindObjectOfType<BasicInput>();
        basicInput.enabled = true;

        FollowAI[] followai = FindObjectsOfType<FollowAI>();
        foreach (FollowAI v in followai)
        {
            v.enabled = true;
        }

}

}
