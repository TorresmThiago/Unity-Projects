using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongTower : Tower
{
    void Start()
    {
        cooldownTime = 2.25f;
        damage = 2f;
    }
}
