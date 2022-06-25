using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ConstructTower(string towerType)
    {
        switch (towerType)
        {
            case "simple":
                Debug.Log("Contruct the simple type tchuwtchuw");
                break;
            case "fast":
                Debug.Log("Contruct the fast type KATCHAU");
                break;
            case "strong":
                Debug.Log("Contruct the strong type KATBUUUM");
                break;
        }

        animator.SetTrigger("Close");

    }
}
