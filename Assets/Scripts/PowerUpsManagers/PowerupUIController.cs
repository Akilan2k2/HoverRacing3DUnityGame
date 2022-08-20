using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerupUIController : MonoBehaviour
{

    public mypowerupscript MyPowerupScript;

    public GameObject PowerSlot1bg;
    Image PowerSlot1Image;
    public GameObject PowerSlot2bg;
    Image PowerSlot2Image;
    public GameObject PowerSlot3bg;
    Image PowerSlot3Image;





    public Sprite MissileIcon;
    public Sprite ShieldIcon;
    public Sprite LaserIcon;
    public Sprite Empty;


    // Start is called before the first frame update
    void Awake()
    {

        PowerSlot1Image = PowerSlot1bg.GetComponent<Image>();

        PowerSlot2Image = PowerSlot2bg.GetComponent<Image>();

        PowerSlot3Image = PowerSlot3bg.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        //Slot1
        if (MyPowerupScript.PowerSlot1 == 1)
        {
            PowerSlot1Image.sprite = ShieldIcon;
        }

        if (MyPowerupScript.PowerSlot1 == 2)
        {
            PowerSlot1Image.sprite = LaserIcon;
        }

        if (MyPowerupScript.PowerSlot1 == 3)
        {
            PowerSlot1Image.sprite = MissileIcon;
        }

        if (MyPowerupScript.PowerSlot1 == 4)
        {

        }

        if (MyPowerupScript.PowerSlot1 == 0)
        {
            PowerSlot1Image.sprite = Empty;
        }


        //Slot2
        if (MyPowerupScript.PowerSlot2 == 1)
        {
            PowerSlot2Image.sprite = ShieldIcon;
        }

        if (MyPowerupScript.PowerSlot2 == 2)
        {
            PowerSlot2Image.sprite = LaserIcon;
        }

        if (MyPowerupScript.PowerSlot2 == 3)
        {
            PowerSlot2Image.sprite = MissileIcon;
        }

        if (MyPowerupScript.PowerSlot2 == 4)
        {

        }

        if (MyPowerupScript.PowerSlot2 == 0)
        {
            PowerSlot2Image.sprite = Empty;
        }


        //Slot3
        if (MyPowerupScript.PowerSlot3 == 1)
        {
            PowerSlot3Image.sprite = ShieldIcon;
        }

        if (MyPowerupScript.PowerSlot3 == 2)
        {
            PowerSlot3Image.sprite = LaserIcon;
        }

        if (MyPowerupScript.PowerSlot3 == 3)
        {
            PowerSlot3Image.sprite = MissileIcon;
        }

        if (MyPowerupScript.PowerSlot3 == 4)
        {

        }

        if (MyPowerupScript.PowerSlot3 == 0)
        {
            PowerSlot3Image.sprite = Empty;
        }

    }

    


}
