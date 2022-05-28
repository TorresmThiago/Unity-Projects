using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField]
    private Color _baseColor, _offsetColor;

    [SerializeField]
    private SpriteRenderer _renderer;

    private GameObject Carrot;

    public bool hasCarrot;


    private void OnEnable()
    {
        PlayerBehaviour.OnEatCarrot += ChangeCarrotPosition;
    }

    private void ChangeCarrotPosition()
    {
        if (hasCarrot)
        {
            hasCarrot = false;

            Tile randomTile;
            bool validPosition;

            do
            {
                int randomX = UnityEngine.Random.Range(0, GridManager.Instance._gridWidth);
                int randomY = UnityEngine.Random.Range(0, GridManager.Instance._gridHeight);
                randomTile = GridManager.Instance.GetTileAtPosition(new Vector2(randomX, randomY));
                validPosition = randomTile.transform.childCount == 0;
            } while (!validPosition);

            randomTile.hasCarrot = true;
        }
    }

    public void Init(bool isOffset, GameObject carrotObject = null, bool tileWithCarrot = false)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
        Carrot = carrotObject;
        hasCarrot = tileWithCarrot;
    }

    private void Update()
    {
        if (hasCarrot)
        {
            Carrot.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            Carrot.transform.parent = transform;
        }
    }


}
