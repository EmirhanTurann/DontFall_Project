using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPush : MonoBehaviour
{
    
    Rigidbody EnemyRB;
    public string LastObjectName;
    public int score;

    private void Update()
    {
        Debug.Log(this.gameObject.name+" Puan "+score);
    }



    void push() 
    {

        EnemyRB.AddForce(this.transform.forward * 50);
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            EnemyRB = collision.rigidbody;
            push();
            LastObjectName = collision.gameObject.name;
           
          
            
            
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FallArea")
        {
          // Destroy(this.gameObject);
           
            



        }
    }
}
