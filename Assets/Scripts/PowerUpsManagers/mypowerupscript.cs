using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RVP;

public class mypowerupscript : MonoBehaviour
{
    public VehicleParent thisVehicle;

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
    public GameObject ShieldObject;
    public Transform ShieldSpawner;



    bool IsPowerCollectable;

   public bool IsSlot1empty=true;
   public bool IsSlot2empty=true;
   public bool IsSlot3empty=true;




    private void Start()
    {
        
    }

    void Update()
    {
        checkSlot();

        if(Input.GetKeyDown(KeyCode.I))
        {
            PowerSlot1State();
        }
    
        if(Input.GetKeyDown(KeyCode.O))
        {
            PowerSlot2State();

        }

        
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            PowerSlot3State();

        }




    }


    
    
    void PowerSlot1State()
    {
        switch (PowerSlot1)
        {
            case 0:
                Debug.Log("No Powers");

                break;

            case 1:

                StartCoroutine(UseShield());
                PowerSlot1 = 0;
                break;

            case 2:
                StartCoroutine(UseCannon());
                PowerSlot1 = 0;


                break;

            case 3:
                UseMissile();
                PowerSlot1 = 0;
                break;
        }
    }


    void PowerSlot2State()
    {
        switch (PowerSlot2)
        {
            case 0:
                Debug.Log("No Powers");
                PowerSlot2 = 0;
                break;

            case 1:

                StartCoroutine(UseShield());
                PowerSlot2 = 0;
                break;

            case 2:
                StartCoroutine(UseCannon());
                PowerSlot2 = 0;
                break;

            case 3:
                UseMissile();
                PowerSlot2 = 0;
                break;
        }
    }




    void PowerSlot3State()
    {
        switch (PowerSlot3)
        {
            case 0:
                Debug.Log("No Powers");

                break;

            case 1:

                StartCoroutine(UseShield());
                PowerSlot3 = 0;

                break;

            case 2:
                StartCoroutine(UseCannon());
                PowerSlot3 = 0;


                break;

            case 3:
                UseMissile();
                PowerSlot3 = 0;
                break;

        }
    }


















   

    float ShieldDuration = 10;

    IEnumerator UseShield()

    {
        thisVehicle.IsShielded = true;
        var ShieldInstance = Instantiate(ShieldObject, ShieldSpawner.position, ShieldSpawner.rotation);
        ShieldInstance.transform.SetParent(thisVehicle.transform);
        yield return new WaitForSeconds(ShieldDuration);
        thisVehicle.IsShielded = false;
        Destroy(ShieldInstance);
        Debug.Log("using shield");
        
    }

   
    
    
    
    
    void UseMissile()
    {
        Rigidbody MissileInstance;
        MissileInstance = Instantiate(MissileObject, MissileSpawner.position, MissileSpawner.rotation).GetComponent<Rigidbody>();

        MissileInstance.velocity = carRB.velocity;
        MissileInstance.AddForce(MissileSpawner.forward * 40, ForceMode.Impulse);
        MissileInstance.GetComponent<MissileBeheviour>().spawnerVehicle = thisVehicle;
        Debug.Log("using misslie");
   
    }

    
    
    IEnumerator UseCannon(int count=50)
    {

        int bulletrate = 0;

        while (bulletrate<count)

        {
            Rigidbody BulletInstance;

            bulletrate++;

            BulletInstance = Instantiate(BulletObject, BulletSpawner.position, BulletSpawner.rotation).GetComponent<Rigidbody>();
            BulletInstance.velocity = carRB.velocity;
            BulletInstance.AddForce(BulletSpawner.forward * 100, ForceMode.Impulse);

            BulletInstance.GetComponent<LaserBeheviour>().spawnerVehicle = thisVehicle;

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
