using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTower : Tower
{
    void Awake()
    {
        cooldownTime = 1.5f;
    }
}
