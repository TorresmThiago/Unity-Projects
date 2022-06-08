using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Shoot shoot;

    private float speed;
    private float verticalInput;
    private float horizontalInput;
    private bool inCooldown;

    void Update()
    {
        speed = 4f;
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

        if ((horizontalInput == 1 && transform.position.x >= 8.3f)
          || horizontalInput == -1 && transform.position.x <= -8.3f)
        {
            horizontalInput = 0;
        }

        if ((verticalInput == 1 && transform.position.y >= 4.3f)
        || verticalInput == -1 && transform.position.y <= -4.3f)
        {
            verticalInput = 0;
        }

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }
}
