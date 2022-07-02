using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float cooldownTime;
    public float damage;

    [SerializeField]
    private Shoot _shoot;

    private SpriteRenderer spriteRenderer;

    private Coroutine shootingCoroutine;

    private List<Transform> onRange;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
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
        if (other.gameObject.tag == "Enemy")
        {
            onRange.Add(other.transform);
            if (onRange.Count == 1) shootingCoroutine = StartCoroutine(Shooting());
        }
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            _shoot.enemyTarget = onRange[0];
            Shoot shoot = Instantiate(_shoot, transform.position, transform.rotation);
            Animation animation = gameObject.GetComponent<Animation>();

            animation.Play("TowerShoot");
            yield return new WaitForSeconds(cooldownTime);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            onRange.Remove(other.transform);
            if (onRange.Count == 0) StopCoroutine(shootingCoroutine);
        }
    }
}
