using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField]
    private int  _gridWidth,  _gridHeight;
    
    [SerializeField]
    private Tile _tile; 

    [SerializeField]
    private Transform _cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        
    }

    void GenerateGrid()
    {
        for (int x = 0; x <  _gridWidth; x++)
        {
            for (int y = 0; y <  _gridHeight; y++)
            {
                Tile spawnedTile = Instantiate(_tile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = "Tile_" + x + "_" + y;
            
                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
            }
        }

        _cameraTransform.position = new Vector3((float) _gridWidth / 2 - .5f, (float ) _gridHeight / 2 - .5f, -10);
    }

}
