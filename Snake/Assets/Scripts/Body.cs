using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    private bool isTail;

    public void Move(Vector3 position)
    {
        transform.position = position;
    }

    // UPDATE POSITION
    //  move function
    //  variable object following
    //  get diference on last position and new position to determine direction
    // 

    // INSTANTIATE NEXT BODY OBJECT
    //  Listen to eatCarrot Event
    //  if the body part is tail, instantiate next based on this.position

}
