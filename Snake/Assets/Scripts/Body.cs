using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private Body nextBodyPart;

    private void OnEnable()
    {
        PlayerBehaviour.OnEatCarrot += IncreaseBody;
    }

    private void IncreaseBody()
    {
        PlayerBehaviour.OnEatCarrot -= IncreaseBody;
        nextBodyPart = Instantiate(this, transform.position, transform.rotation, transform.parent);
    }

    public void MoveBodyPart(Transform previousBodyPart)
    {
        if (nextBodyPart != null)
        {
            nextBodyPart.MoveBodyPart(transform);
        }

        transform.rotation = previousBodyPart.rotation;
        transform.position = previousBodyPart.position;
        transform.parent = previousBodyPart.parent;
    }
}
