using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [System.NonSerialized]
    public float speed;

    [System.NonSerialized]
    public float destroyPosition;

    [System.NonSerialized]
    public Vector3 direction;

    [System.NonSerialized]
    public Shooter shooter;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
        DestroyShoot();
    }

    public virtual void DestroyShoot() { }

    public enum Shooter
    {
        Player,
        Enemy
    }
}
