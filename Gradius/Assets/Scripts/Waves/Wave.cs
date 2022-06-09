using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<Enemy> enemyList;

    public bool inlineSpawn;
    public bool spawnAtOnce;

    public bool readyForNextWave;

    public float spawnInterval;
    public float spawnPositionY;

    public bool CallNextWave()
    {
        if (transform.childCount == 0 || readyForNextWave)
            return true;

        return false;
    }
}
