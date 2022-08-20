using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RVP;

public class LaserBeheviour : MonoBehaviour
{
    public VehicleParent spawnerVehicle;
     
    public float DamageForce = 20;
    public float radious = 1;

    public float drag = -5;


     
    
    void Start()
    {
        AudioSource Lasersound = GetComponent<AudioSource>();
       // Rigidbody RigidbodyLaser = GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
        Lasersound.Play();
    }

  
    private void OnTriggerEnter(Collider other)
    {


        if (other.transform.parent != null && other.transform.parent.TryGetComponent(out VehicleParent vehicle))
        {
            if (vehicle == spawnerVehicle)
                return;
            if (vehicle.IsShielded)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Rigidbody Rb = other.transform.parent.GetComponent<Rigidbody>();

                Rb.velocity /= 4000;

                Rb.AddExplosionForce(DamageForce, transform.position, radious);


                Rb.velocity = Rb.velocity * 0.80f * Time.deltaTime;
            }


        }
    }

            
        
         
    
     
        
   
    

   

}
