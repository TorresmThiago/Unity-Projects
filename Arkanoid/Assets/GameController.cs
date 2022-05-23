using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Block GameObject
    public GameObject prefab;

    //Grid Size
    public int gridX = 9;
    public int gridY = 4;

    //Space between blocks
    private readonly float horizontalSpacing = 2.15f;
    private readonly float verticalSpacing = 1.08f;

    //Offset for blocks
    private readonly float horizontalOffset = 8.64f;
    private readonly float verticalOffset = 1.72f;


    //TODO: Instantiate blocks inside an empty gameObject

    void Start()
    {
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                Vector3 blockPosition = new Vector3(horizontalSpacing * x - horizontalOffset,
                                                    verticalSpacing * y + verticalOffset,
                                                    0);
                Instantiate(prefab, blockPosition, Quaternion.identity);
            }
        }
    }

}
