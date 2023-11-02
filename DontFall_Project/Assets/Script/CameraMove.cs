using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed=1f;
    public GameObject Character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera follow system
        transform.position = Vector3.Lerp(transform.position,new Vector3(Character.transform.position.x,transform.position.y, Character.transform.position.z-14), Time.deltaTime* speed);
    }
}
