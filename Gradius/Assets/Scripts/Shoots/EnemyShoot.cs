using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Shoot
{
    void Start()
    {
        direction = Vector3.left;
        destroyPosition = -15f;
        speed = 10f;
        shooter = Shooter.Enemy;
    }

    public override void DestroyShoot()
    {
        if (transform.position.x < destroyPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
