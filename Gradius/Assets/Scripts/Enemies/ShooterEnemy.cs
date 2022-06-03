using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{

    //Code from Unity Documentation in order to learn about Linear Interpolation

    public EnemyShoot shoot;

    public Vector3 startPosition;
    public Vector3 endPosition;

    public float speed = 1.0F;

    private float startTime;
    private float distance;
    private float distCovered;
    private float fractionOfJourney;

    void Start()
    {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, endPosition);
        StartCoroutine(EnemyShoot());
    }


    void Update()
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
        yield return new WaitForSeconds(.25f);
        if (transform.position.x <= endPosition.x)
        {
            Instantiate(shoot, transform.position, Quaternion.identity);
        }
        StartCoroutine(EnemyShoot());
    }

}
