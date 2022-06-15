using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform enemyTarget;
    public float speed;

    private void Start()
    {
        speed = 10;
    }

    void Update()
    {
        LookAtTarget(enemyTarget);
        MoveToTarget(enemyTarget);
    }

    private void LookAtTarget(Transform target)
    {
        Quaternion rotation = Quaternion.LookRotation
                    (target.position - transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    private void MoveToTarget(Transform target)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log("TODO: Apply damage to enemy!");
            Destroy(gameObject);
        }
    }
}