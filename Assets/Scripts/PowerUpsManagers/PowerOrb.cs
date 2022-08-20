using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PowerOrb : MonoBehaviour
{

    //giving powers for Player
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            mypowerupscript myPowerupscript =other.GetComponent<mypowerupscript>();
            AudioSource PickupSound = GetComponent<AudioSource>();
            if(myPowerupscript.IsSlot1empty)
            {
                myPowerupscript.PowerSlot1 = Random.Range(1,4);
                PickupSound.Play();
             
            }

            else
            {
                if(myPowerupscript.IsSlot2empty)
                {
                    myPowerupscript.PowerSlot2 = Random.Range(1,4);
                    PickupSound.Play();

                }
                 
                else
                {
                    if (myPowerupscript.IsSlot3empty)
                    {
                        myPowerupscript.PowerSlot3 = Random.Range(1,4);
                        PickupSound.Play();

                    }
                }
            
            
            }

        }

        
        //give powers for AI
        if(other.tag == "AI")
        {
            AiPowerUp AiPowerupscript = other.GetComponent<AiPowerUp>();
           
            if (AiPowerupscript.IsSlot1empty)
            {
                AiPowerupscript.PowerSlot1 = Random.Range(1, 4);
                

            }

            else
            {
                if (AiPowerupscript.IsSlot2empty)
                {
                    AiPowerupscript.PowerSlot2 = Random.Range(1, 4);
                    

                }

                else
                {
                    if (AiPowerupscript.IsSlot3empty)
                    {
                        AiPowerupscript.PowerSlot3 = Random.Range(1, 4);
                        

                    }
                }


            }

        }






    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        //mypowerupscript myPowerupscript = GetComponent<mypowerupscript>();
    }



}
