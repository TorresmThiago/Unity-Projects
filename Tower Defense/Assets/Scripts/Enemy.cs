using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public List<Vector3> targetList;
    public float speed;

    private int currentTarget;

    void Start()
    {
        currentTarget = 0;
    }

    void Update()
    {
        if (transform.position.x > 10f)
            Destroy(gameObject);

        if (transform.position == targetList[currentTarget])
            currentTarget++;

        LookAtDirection();
        MoveToPosition();
    }

    private void LookAtDirection()
    {
        Quaternion rotation = Quaternion.LookRotation
                    (targetList[currentTarget] - transform.position, transform.TransformDirection(Vector3.right));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    private void MoveToPosition()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetList[currentTarget], step);
    }

}
