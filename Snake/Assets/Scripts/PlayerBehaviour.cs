using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerBehaviour : MonoBehaviour
{
    private string _direction;
    private GameObject _gridManager;

    void Start()
    {
        _gridManager = GameObject.FindGameObjectWithTag("GridManager");
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
            _direction = "up";
            transform.eulerAngles = Vector3.forward * 180;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = "left";
            transform.eulerAngles = Vector3.forward * 270;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = "right";
            transform.eulerAngles = Vector3.forward * 90;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = "down";
            transform.eulerAngles = Vector3.forward * 0;
        }
    }

    IEnumerator PlayerMovement()
    {
        yield return new WaitForSeconds(.75f);

        switch (_direction)
        {
            case ("up"):
                Move(Vector2.up);
                break;
            case ("left"):
                Move(Vector2.left);
                break;
            case ("right"):
                Move(Vector2.right);
                break;
            case ("down"):
                Move(Vector2.down);
                break;
            default: break;
        }
        //_lastDirection = _direction;
        StartCoroutine(PlayerMovement());
    }

    void Move(Vector2 movement)
    {
        string[] parentName = transform.parent.name.Split('_');
        Vector2 currentTilePosition = new Vector2(Int32.Parse(parentName[1]), Int32.Parse(parentName[2]));

        Vector2 newPosition = currentTilePosition + movement;
        Tile nextTile = _gridManager.GetComponent<GridManager>().GetTileAtPosition(newPosition);
        if (nextTile != null)
        {
            transform.position = new Vector3(nextTile.transform.position.x, nextTile.transform.position.y, -1);
            transform.parent = nextTile.transform;
        }

    }
}
