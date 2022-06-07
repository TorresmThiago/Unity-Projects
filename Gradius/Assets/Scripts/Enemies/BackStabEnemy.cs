using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackStabEnemy : Enemy
{

    float t;

    private void Start()
    {
        speed = 100f;
    }


    public override void EnemyMovement()
    {
        float currentSpeed = speed * Mathf.Lerp(0, 1, t);
        t += 0.0125f * Time.deltaTime;

        transform.Translate(Vector3.right * Time.deltaTime * currentSpeed, Space.World);
        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }


    }
}
