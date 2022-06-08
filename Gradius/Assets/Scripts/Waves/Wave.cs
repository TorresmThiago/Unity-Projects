using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<Enemy> enemyList;
    public float spawnInterval;
    public bool inlineSpawn;
    public bool spawnAtOnce;
    public float spawnPositionY;
}
