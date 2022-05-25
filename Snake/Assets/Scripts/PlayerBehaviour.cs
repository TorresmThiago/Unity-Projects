using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int stepDistance;
    private string direction;

    void Start()
    {
        direction = "";
        StartCoroutine(playerMovement());
    }

    void Update()
    {
        playerDirection();
    }

    void playerDirection()
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

    IEnumerator playerMovement()
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

        StartCoroutine(playerMovement());
    }
}
