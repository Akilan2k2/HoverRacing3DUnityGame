using RVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBeheviour : MonoBehaviour
{
    public LayerMask GroundLayer;

    public VehicleParent spawnerVehicle;
    
    public float DamageForce = 2;

    Rigidbody Rigidbodymissile;
   
    
    void Start()
    {
       

        Rigidbodymissile = GetComponent<Rigidbody>();
        Destroy(gameObject, 10);
    
    }

  
    void FixedUpdate()
    {
        RaycastHit rayhit;

        if (Physics.Raycast(transform.position, Vector3.down, out rayhit, 1.5f, GroundLayer))
        {
            Rigidbodymissile.AddForce(transform.up * 20);
        }

        else
        {
            Rigidbodymissile.AddForce(Vector3.down * 40);
        }

       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.transform.parent !=null && other.transform.parent.TryGetComponent(out VehicleParent vehicle))
        {
            if (vehicle == spawnerVehicle)
                return;
            if (vehicle.IsShielded)
            {
                Destroy(gameObject);
                return;
            }

            Rigidbody Rb = other.transform.parent.GetComponent<Rigidbody>();
            
            const float carStunTime = 3;
            vehicle.StartCoroutine(ResetMissileHit(vehicle, carStunTime));

            Rb.velocity = Vector3.zero;
            Rb.drag = 50;
            var direction = Rb.position - transform.position;
            var projectedDirection = Vector3.Project(direction, Rb.transform.forward);
            var sideForce = direction - projectedDirection;
            sideForce.y = 0;
            
            Rb.AddForceAtPosition(-sideForce.normalized * DamageForce,transform.position,ForceMode.VelocityChange);
            Destroy(gameObject);
        
        }
        
    
    
    
    }
    private IEnumerator ResetMissileHit(VehicleParent vehicle, float time)
    {
        
        foreach (var wheel in vehicle.hoverWheels)
        {
            wheel.enabled = false;
        }
        yield return new WaitForSeconds(time);
        foreach (var wheel in vehicle.hoverWheels)
            wheel.enabled = true;
        Rigidbody Rb = vehicle.GetComponent<Rigidbody>();
        Rb.drag = 0;


    }


}
