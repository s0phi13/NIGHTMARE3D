using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform myPlatform;
    public Transform myStartPoint;
    public Transform myEndPoint;

    public float platformSpeed;
    bool isReversing = false;

    // Start is called before the first frame update
    void Start()
    {
        
        myPlatform.position = myStartPoint.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isReversing == false)
        {
           myPlatform.position = Vector3.MoveTowards(myPlatform.position, myEndPoint.position, platformSpeed);
        }
        else
        {
             myPlatform.position = Vector3.MoveTowards(myPlatform.position, myStartPoint.position, platformSpeed);
        }
        
        if (myPlatform.position == myEndPoint.position)
           {
               isReversing = true;
           }
        else
             {
                 isReversing = false;
             }
    }
}
