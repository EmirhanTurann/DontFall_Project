using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjectSpawn : MonoBehaviour
{
    public GameObject SpawnObject;
    int collectObkectCount;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        GameObject[] allCollectObject = GameObject.FindGameObjectsWithTag("Collect");
         collectObkectCount = allCollectObject.Length;
        
    }
    //function that randomly spawns collectible objects
    public IEnumerator  SpawnCollectObject()
    {   

        while (collectObkectCount < 10)
        {
        
             var position = new Vector3(Random.Range(-10.0f, 10.0f), this.transform.position.y, Random.Range(-10.0f, 10.0f));
            Instantiate(SpawnObject, position, Quaternion.identity);

            yield return new WaitForSeconds(1);
            
           
        }

    }
}
