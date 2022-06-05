using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndulationEnemy : Enemy
{

    public float magnitude;
    public float waveSpeed;
    public float startTime;

    private void Start()
    {
        speed = 1;
        waveSpeed = 2;
        magnitude = 4;
        startTime = Time.time;
    }


    public override void EnemyMovement()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        transform.position = new Vector2(transform.position.x, Mathf.Sin(Time.time - startTime * waveSpeed) * magnitude);

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
