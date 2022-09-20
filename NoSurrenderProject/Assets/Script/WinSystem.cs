using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    public GameObject WinCamera;
    public PauseAndResumeSystem script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {

        }
        GameObject[] Wins = GameObject.FindGameObjectsWithTag("Win");
        foreach (var item in Wins)
        {
           
            WinCamera.transform.position = item.gameObject.transform.position = new Vector3(item.gameObject.transform.position.x-0.2f,item.gameObject.transform.position.y, item.gameObject.transform.position.z-4);
        } 
    }
}
