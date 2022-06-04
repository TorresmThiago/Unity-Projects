using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private Shoot shoot;


    private float verticalInput;
    private float horizontalInput;
    private bool inCooldown;

    void Update()
    {
        PlayerMovement();
        PlayerAction();
    }


    private void PlayerAction()
    {
        if (Input.GetKey("space") && !inCooldown)
        {
            Instantiate(shoot, transform.position, Quaternion.identity);
            inCooldown = true;
            StartCoroutine(ShootCooldown());
        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(.25f);
        inCooldown = false;
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }
}
