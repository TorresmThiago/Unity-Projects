using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTower : Tower
{
    void Awake()
    {
        cooldownTime = .75f;
    }
}
