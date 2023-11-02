using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public Touch touch;
    public bool startMove;
    private Vector3 touchLast;
    private Vector3 touchFirst;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {

                startMove = true;
                /*_isMoving = true;*/
                touchLast = touch.position;
                touchFirst = touch.position;
                
            }
            if (startMove)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    touchFirst = touch.position;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    touchFirst = touch.position;
                    //  _isMoving = false;
                    startMove = false;
                }
                gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), 500 * Time.deltaTime);
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 5);
            }
        }




    }
    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
      
        return temp;
    }
    Vector3 CalculateDirection()
    {
        Vector3 temp = (touchFirst - touchLast);
        
        temp.z = temp.y;
        temp.y = 0;
       

        return temp;
        
    }
}
