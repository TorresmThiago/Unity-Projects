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
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * Time.deltaTime * _speed, Space.World);
    }
}
