using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public List<Vector3> targetList;
    public float speed;
    public int healthPoints;

    private int currentTarget;

    void Start()
    {
        currentTarget = 0;
    }

    void Update()
    {
        if (transform.position.x > 10f || healthPoints == 0)
            Destroy(gameObject);

        if (transform.position == targetList[currentTarget])
            currentTarget++;

        LookAtDirection();
        MoveToPosition();
    }

    public void DamageTaken() { healthPoints--; }

    private void LookAtDirection()
    {
        Quaternion rotation = Quaternion.LookRotation(targetList[currentTarget] - transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        transform.Rotate(Vector3.back * 90);

    }

    private void MoveToPosition()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetList[currentTarget], step);
    }

}
