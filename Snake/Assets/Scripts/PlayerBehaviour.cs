using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int stepDistance;
    private string direction;
    private string lastDirection;

    void Start()
    {
        StartCoroutine(PlayerMovement());
    }

    void Update()   
    {
        PlayerDirection();
    }

    void PlayerDirection()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = "up";
            transform.eulerAngles = Vector3.forward * 180;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = "left";
            transform.eulerAngles = Vector3.forward * 270;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = "right";
            transform.eulerAngles = Vector3.forward * 90;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = "down";
            transform.eulerAngles = Vector3.forward * 0;
        }
    }

    IEnumerator PlayerMovement()
    {
        yield return new WaitForSeconds(1);

        switch (direction)
        {
            case ("up"):
                transform.position = transform.position + Vector3.up;
                break;
            case ("left"):
                transform.position = transform.position + Vector3.left;
                break;
            case ("right"):
                transform.position = transform.position + Vector3.right;
                break;
            case ("down"):
                transform.position = transform.position + Vector3.down;
                break;
            default: break;
        }
        lastDirection = direction;
        StartCoroutine(PlayerMovement());
    }
}
