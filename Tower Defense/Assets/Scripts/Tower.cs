using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float cooldownTime;

    [SerializeField]
    private Shoot _shoot;

    private Coroutine shootingCoroutine;

    private List<Transform> onRange;

    private void Start()
    {
        onRange = new List<Transform>();
    }

    void Update()
    {
        if (onRange.Count != 0)
            LookAtEnemy(onRange[0]);
        else
            transform.rotation = new Quaternion();
    }

    private void LookAtEnemy(Transform target)
    {
        Quaternion rotation = Quaternion.LookRotation
                    (target.transform.position - transform.position, transform.TransformDirection(Vector3.back));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        onRange.Add(other.transform);
        if (onRange.Count == 1) shootingCoroutine = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            _shoot.enemyTarget = onRange[0];
            Shoot shoot = Instantiate(_shoot, transform.position, transform.rotation);
            yield return new WaitForSeconds(cooldownTime);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onRange.Remove(other.transform);
        if (onRange.Count == 0) StopCoroutine(shootingCoroutine);
    }
}
