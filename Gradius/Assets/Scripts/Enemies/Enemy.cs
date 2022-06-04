using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [System.NonSerialized]
    public float speed;

    public virtual void EnemyMovement() { }

    public virtual void EnemyAction() { }

    void Update()
    {
        EnemyMovement();
    }
}