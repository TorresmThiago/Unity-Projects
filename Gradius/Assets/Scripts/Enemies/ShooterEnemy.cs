using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{

    //Code from Unity Documentation in order to learn about Linear Interpolation

    public EnemyShoot shoot;

    public Vector3 startPosition;
    public Vector3 endPosition;

    private float startTime;
    private float distance;
    private float distCovered;
    private float fractionOfJourney;

    void Start()
    {
        speed = 1f;
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, endPosition);
        StartCoroutine(EnemyShoot());
    }

    public override void EnemyMovement()
    {
        if (fractionOfJourney <= 1)
        {
            distCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distCovered / distance;
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
        }
    }

    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(1.25f);
        if (transform.position.x <= endPosition.x)
        {
            Instantiate(shoot, transform.position, Quaternion.identity);
        }
        StartCoroutine(EnemyShoot());
    }

}
