using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<Enemy> enemyList;

    public bool readyForNextWave;

    public float spawnInterval;

    public bool CallNextWave()
    {
        if (transform.childCount == 0 || readyForNextWave)
            return true;

        return false;
    }
}
