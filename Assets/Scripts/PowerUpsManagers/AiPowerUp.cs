using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPowerUp : MonoBehaviour
{
    public int PowerSlot1;
    public int PowerSlot2;
    public int PowerSlot3;

    public Rigidbody carRB;
    [Header("Power up Objects")]

    [Header("Missile")]
    public Rigidbody MissileObject;
    public Transform MissileSpawner;
    [Header("Bullet")]
    public Rigidbody BulletObject;
    public Transform BulletSpawner;
    [Header("Shield")]
    public Rigidbody ShieldObject;
    public Transform ShieldSpawner;



    bool IsPowerCollectable;

    public bool IsSlot1empty = true;
    public bool IsSlot2empty = true;
    public bool IsSlot3empty = true;






    void Update()
    {
        checkSlot();

    }




  public  void PowerSlot1State()
    {
        switch (PowerSlot1)
        {
            case 0:
                Debug.Log("No Powers");

                break;

            case 1:

                UseShield();

                break;

            case 2:
                UseCannon();
               


                break;

            case 3:
                UseMissile();

                break;
        }
    }


   public void PowerSlot2State()
    {
        switch (PowerSlot2)
        {
            case 0:
                Debug.Log("No Powers");

                break;

            case 1:

                UseShield();

                break;

            case 2:
                UseCannon();



                break;

            case 3:
                UseMissile();

                break;
        }
    }




   public void PowerSlot3State()
    {
        switch (PowerSlot3)
        {
            case 0:
                Debug.Log("No Powers");

                break;

            case 1:

                UseShield();

                break;

            case 2:
                UseCannon();



                break;

            case 3:
                UseMissile();

                break;

        }
    }


















    void UseBoost()

    {
        Debug.Log("using boost");
        PowerSlot1 = 0;
    }

    void UseShield()

    {

        Rigidbody ShieldInstance;
        ShieldInstance = Instantiate(ShieldObject, ShieldSpawner.position, ShieldSpawner.rotation).GetComponent<Rigidbody>();
        ShieldInstance.velocity = carRB.velocity;

        Debug.Log("using shield");
        //PowerSlot2 = 0;
    }






    void UseMissile()
    {
        Rigidbody MissileInstance;
        MissileInstance = Instantiate(MissileObject, MissileSpawner.position, MissileSpawner.rotation).GetComponent<Rigidbody>();

        MissileInstance.velocity = carRB.velocity;
        MissileInstance.AddForce(MissileSpawner.forward * 100, ForceMode.Impulse);

        Debug.Log("using misslie");
        //PowerSlot3 = 0;

    }



    IEnumerator UseCannon(int count = 50)
    {

        int bulletrate = 0;

        while (bulletrate < count)

        {
            Rigidbody BulletInstance;

            bulletrate++;

            BulletInstance = Instantiate(BulletObject, BulletSpawner.position, BulletSpawner.rotation).GetComponent<Rigidbody>();
            BulletInstance.velocity = carRB.velocity;
            BulletInstance.AddForce(BulletSpawner.forward * 100, ForceMode.Impulse);

            yield return new WaitForSeconds(0.2f);

        }
        Debug.Log("using cannon");


    }




    void checkSlot()
    {

        if (PowerSlot1 != 0)
            IsSlot1empty = false;

        else
            IsSlot1empty = true;


        if (PowerSlot2 != 0)
            IsSlot2empty = false;
        else
            IsSlot2empty = true;


        if (PowerSlot3 != 0)
            IsSlot3empty = false;
        else
            IsSlot3empty = true;
    }

}
