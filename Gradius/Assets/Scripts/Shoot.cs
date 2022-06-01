using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float speed;

    void Start()
    {
        speed = 10;
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);

        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
