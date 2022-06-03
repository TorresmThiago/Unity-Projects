using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float speed;

    private void Start()
    {
        speed = 1;
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}