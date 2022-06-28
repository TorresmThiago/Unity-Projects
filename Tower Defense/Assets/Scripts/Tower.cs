using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float cooldownTime;

    [SerializeField]
    private Shoot _shoot;

    private RectTransform rectTransform;

    private Coroutine shootingCoroutine;

    private List<Transform> onRange;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        onRange = new List<Transform>();
    }

    void Update()
    {
        if (onRange.Count != 0)
            LookAtEnemy(onRange[0]);
        else
            rectTransform.rotation = new Quaternion();
    }

    private void LookAtEnemy(Transform target)
    {
        Quaternion rotation = Quaternion.LookRotation
                    (target.transform.position - rectTransform.position, rectTransform.TransformDirection(Vector3.back));
        rectTransform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
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
            Shoot shoot = Instantiate(_shoot, rectTransform.position, rectTransform.rotation);
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
