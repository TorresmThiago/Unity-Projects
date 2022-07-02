using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTower : Tower
{
    void Start()
    {
        cooldownTime = .75f;
        damage = .5f;
    }
}
