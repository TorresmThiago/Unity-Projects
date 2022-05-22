using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private float playerInput;

    public float horizontalSpeed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerInput = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(playerInput * horizontalSpeed, 0);
    }
}
