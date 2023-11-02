using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    public EnemyPush[] allEnemies;
    bool score›nc;
    string ColObjectName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        //The part that increases the points when the characters collect collectibles
         allEnemies = GameObject.FindObjectsOfType<EnemyPush>();

        if (score›nc == true)
        {
           
            for (int i = 0; i < allEnemies.Length; i++)
            {

                if (allEnemies[i].gameObject.name.ToString() == ColObjectName.ToString())
                {

                    allEnemies[i].score+=10;
                    score›nc = false;
                    Destroy(this.gameObject);


                }

            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            ColObjectName = other.gameObject.name;
            score›nc = true;
         
        }
    }
}
