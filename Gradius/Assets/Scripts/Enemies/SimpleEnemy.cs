using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    private void Start()
    {
        speed = 3f;
    }

    public override void EnemyMovement()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}