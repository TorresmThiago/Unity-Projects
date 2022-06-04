using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Shoot
{
    void Start()
    {
        direction = Vector3.left;
        destroyPosition = -15f;
        speed = 5f;
        shooter = Shooter.Enemy;
    }

    public override void DestroyShoot()
    {
        if (transform.position.x < destroyPosition)
        {
            Destroy(gameObject);
        }
    }
}
