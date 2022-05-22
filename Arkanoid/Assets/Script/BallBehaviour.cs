using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private Vector2 currentSpeed;

    public Vector2 ballSpeed;
    public GameObject playerPallet;
    public Vector2 speedLimit;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerPallet = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        /*
            The 'proper' way would be to apply a force in the opposite direction of the 
            rigidbody's velocity. The amount of force should be proportional to the extent 
            to which the rigidbody is exceeding its speed limit.
        */

        currentSpeed = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y);
        AdjustSpeed(currentSpeed);
    }

    private void AdjustSpeed(Vector2 currentSpeed)
    {
        int isXPositive = Mathf.Sign(currentSpeed.x) == 1 ? -1 : 1;
        int isYPositive = Mathf.Sign(currentSpeed.y) == 1 ? -1 : 1;

        if (Mathf.Abs(currentSpeed.x) > speedLimit.x)
        {
            float speedDiference = (Mathf.Abs(currentSpeed.x) - speedLimit.x) * isXPositive;
            rigidbody.AddForce(new Vector2(speedDiference, 0));
        }

        if (Mathf.Abs(currentSpeed.y) > speedLimit.y)
        {
            float speedDiference = (Mathf.Abs(currentSpeed.y) - speedLimit.y) * isYPositive;
            Debug.Log(speedDiference);
            rigidbody.AddForce(new Vector2(0, speedDiference));
        }
    }

    private void Update()
    {
        if (rigidbody.velocity == Vector2.zero && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(ballSpeed);
        }
        else if (rigidbody.velocity == Vector2.zero)
        {
            transform.position = new Vector3(playerPallet.transform.position.x, transform.position.y, 0);
        }
    }


}

