using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField]
    private int _gridWidth, _gridHeight;

    [SerializeField]
    private Tile _tile;

    [SerializeField]
    private Transform _cameraTransform;

    private Dictionary<Vector2, Tile> _tiles;

    public GameObject player;

    void Start()
    {
        GenerateGrid();
    }
    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < _gridWidth; x++)
        {
            for (int y = 0; y < _gridHeight; y++)
            {
                Tile spawnedTile = Instantiate(_tile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = "Tile_" + x + "_" + y;

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

                //spawnedTile.transform.parent = transform;
                _tiles[new Vector2(x, y)] = spawnedTile;

                if (x == Mathf.Ceil(_gridWidth / 2) && y == Mathf.Ceil(_gridHeight / 2))
                {
                    player.transform.position = new Vector3(spawnedTile.transform.position.x, spawnedTile.transform.position.y, -1);
                    player.transform.parent = spawnedTile.transform;
                }

            }
        }

        _cameraTransform.position = new Vector3((float)_gridWidth / 2 - .5f, (float)_gridHeight / 2 - .5f, -10);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out Tile tile))
        {
            return tile;
        }

        return null;
    }

}
