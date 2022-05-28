using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField]
    private Body _body;

    private Body nextBodyPart;

    private void OnEnable()
    {
        PlayerBehaviour.OnEatCarrot += IncreaseBody;
    }

    private void IncreaseBody()
    {
        PlayerBehaviour.OnEatCarrot -= IncreaseBody;
        Debug.Log("Just got bigger");
        nextBodyPart = Instantiate(_body, transform.position, Quaternion.identity);
    }

    public void MoveBodyPart(Vector3 position)
    {
        if (nextBodyPart != null)
        {
            nextBodyPart.MoveBodyPart(transform.position);
        }

        transform.position = position;
    }
}
