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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (TryGetComponent(out PlayerShoot shoot))
        {
            Debug.Log(shoot.shooter);
        }
        else
        {
            Debug.Log("Ahn...");
        }

        // if (other.transform.tag == "Shoot")
        // {
        //     Destroy(gameObject);
        // }
    }

}