using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public Touch _touch;
    public bool _dragStarted;
    private Vector3 _touchDown;
    private Vector3 _touchUp;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began)
            {
                
                _dragStarted = true;
                /*_isMoving = true;*/
                _touchUp = _touch.position;
                _touchDown = _touch.position;
                
            }
            if (_dragStarted)
            {
                if (_touch.phase == TouchPhase.Moved)
                {
                    _touchDown = _touch.position;
                }

                if (_touch.phase == TouchPhase.Ended)
                {
                    _touchDown = _touch.position;
                    //  _isMoving = false;
                    _dragStarted = false;
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
        Vector3 temp = (_touchDown - _touchUp);
        
        temp.z = temp.y;
        temp.y = 0;
       

        return temp;
        
    }
}
