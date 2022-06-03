using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Shoot
{
    void Start()
    {
        direction = Vector3.right;
        destroyPosition = 15f;
        speed = 10f;
        shooter = Shooter.Player;
    }

    public override void DestroyShoot()
    {
        if (transform.position.x > destroyPosition)
        {
            Destroy(gameObject);
        }
    }
}
