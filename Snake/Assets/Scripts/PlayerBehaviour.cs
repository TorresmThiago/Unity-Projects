using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class PlayerBehaviour : MonoBehaviour
{

    public static event Action OnEatCarrot;
    private string _currentDirection;

    void Start()
    {
        StartCoroutine(PlayerMovement());
    }

    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.upArrowKey.wasPressedThisFrame) _currentDirection = "up";
        if (keyboard.leftArrowKey.wasPressedThisFrame) _currentDirection = "left";
        if (keyboard.rightArrowKey.wasPressedThisFrame) _currentDirection = "right";
        if (keyboard.downArrowKey.wasPressedThisFrame) _currentDirection = "down";
    }

    IEnumerator PlayerMovement()
    {
        yield return new WaitForSeconds(.75f);

        switch (_currentDirection)
        {
            case ("up"):
                Move(Vector2.up, 180);
                break;
            case ("left"):
                Move(Vector2.left, 270);
                break;
            case ("right"):
                Move(Vector2.right, 90);
                break;
            case ("down"):
                Move(Vector2.down, 0);
                break;
            default: break;
        }

        StartCoroutine(PlayerMovement());
    }

    void Move(Vector2 direction, int angles)
    {
        string[] parentName = transform.parent.name.Split('_');
        Vector2 currentTilePosition = new Vector2(Int32.Parse(parentName[1]), Int32.Parse(parentName[2]));

        Vector2 newPosition = currentTilePosition + direction;
        Tile nextTile = GridManager.Instance.GetTileAtPosition(newPosition);

        if (nextTile != null)
        {
            transform.position = new Vector3(nextTile.transform.position.x, nextTile.transform.position.y, -1);
            transform.parent = nextTile.transform;
            transform.eulerAngles = Vector3.forward * angles;

            if (nextTile.hasCarrot) OnEatCarrot.Invoke();
        }

    }
}
