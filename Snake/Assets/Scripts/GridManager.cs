using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public static GridManager Instance;

    [SerializeField]
    public int _gridWidth, _gridHeight;

    [SerializeField]
    private Tile _tile;

    [SerializeField]
    private Transform _cameraTransform;

    private Dictionary<Vector2, Tile> _tiles;

    public PlayerBehaviour player;

    public GameObject carrot;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();

        GameObject spawnedCarrot = Instantiate(carrot);

        for (int x = 0; x < _gridWidth; x++)
        {
            for (int y = 0; y < _gridHeight; y++)
            {
                Tile spawnedTile = Instantiate(_tile, new Vector3(x, y, 1), Quaternion.identity);
                spawnedTile.name = "Tile_" + x + "_" + y;

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);

                if (x == Mathf.Ceil(_gridWidth / 1.3f) && y == Mathf.Ceil(_gridHeight / 2))
                {
                    spawnedTile.Init(isOffset, spawnedCarrot, true);
                }
                else
                {
                    spawnedTile.Init(isOffset, spawnedCarrot);
                }

                spawnedTile.transform.parent = transform;
                _tiles[new Vector2(x, y)] = spawnedTile;

                if (x == Mathf.Ceil(_gridWidth / 2) && y == Mathf.Ceil(_gridHeight / 2))
                {
                    player.transform.position = (Vector2)spawnedTile.transform.position;
                    player.transform.parent = spawnedTile.transform;
                    player.body.MoveBodyPart(player.transform);
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
