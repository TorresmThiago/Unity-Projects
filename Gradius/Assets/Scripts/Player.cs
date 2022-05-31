using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    private float verticalInput;
    private float horizontalInput;

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 directionX = new Vector3(0, 0, 0);

        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 directionY = new Vector3(0, 0, 0);

        if (horizontalInput == 1)
            directionX = Vector3.right;
        else if (horizontalInput == -1)
            directionX = Vector3.left;

        if (verticalInput == 1)
            directionY = Vector3.up;
        else if (verticalInput == -1)
            directionY = Vector3.down;

        transform.Translate(directionX * Time.deltaTime * _speed, Space.World);
        transform.Translate(directionY * Time.deltaTime * _speed, Space.World);


    }
}
