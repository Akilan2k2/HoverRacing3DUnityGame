using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttack : MonoBehaviour
{
    public float SpheareRadious;
    public float MaxDistance;
    public LayerMask layerMask;
    public AiPowerUp AiPowerUp;
    private Vector3 origin;
    private Vector3 direction;

    

    //when Ai ray hit player it fill this value.if this value is filled Ai will attack the player once
    float Airage = 0;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, SpheareRadious, direction, out hit, MaxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            Airage += Time.deltaTime;
        }

        
        if(Airage>=5)
        {
            Attack();
            Airage = 0;
        }
    
    
    
    
    
    
    }


    void Attack()
    {
        

        if (AiPowerUp.PowerSlot1>1)
        {
            AiPowerUp.PowerSlot1State();
            
        }

       else
        {
            if(AiPowerUp.PowerSlot2>1)
            {
                AiPowerUp.PowerSlot2State();
                
            }

            else
            {
                if(AiPowerUp.PowerSlot3>1)
                {
                    AiPowerUp.PowerSlot3State();
                    
                
                }
            }
        
        
        
        }
    
    }










}
