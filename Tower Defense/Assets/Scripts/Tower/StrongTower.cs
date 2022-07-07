using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongTower : Tower
{
    void Awake()
    {
        cooldownTime = 2.25f;
    }
}
