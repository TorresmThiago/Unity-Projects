using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTower : Tower
{
    void Start()
    {
        cooldownTime = 1.5f;
        damage = 1f;
    }
}
