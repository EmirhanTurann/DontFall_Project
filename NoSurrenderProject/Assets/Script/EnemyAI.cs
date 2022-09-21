using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public Transform EnemyTransform;
    NavMeshAgent EnemyNavMesh;
    private void Start()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        findClosetEnemy();
       
    }
    void findClosetEnemy()
    {
        float distanceToClosetEnemy = Mathf.Infinity;
        GameObject closetEnemy = null;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
       

        foreach (GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosetEnemy)
            {
                distanceToClosetEnemy = distanceToEnemy;
                closetEnemy = currentEnemy;
            }
            Debug.DrawLine(this.transform.position, closetEnemy.transform.position);
            
            if (distanceToClosetEnemy > 0f)
            {
                EnemyTransform = closetEnemy.transform;
                EnemyNavMesh.destination = EnemyTransform.transform.position;
                
            }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FallArea")
        {
            StartCoroutine(ExampleCoroutine001());
            IEnumerator
               ExampleCoroutine001()
            { 
                GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().freezeRotation = false;

                yield return new
                    WaitForSeconds(3f);
                GetComponent<NavMeshAgent>().enabled = true;
                GetComponent<Rigidbody>().freezeRotation = true;

            }
        }
      

        
    }
    




}
