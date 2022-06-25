using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public List<Tower> towerList;

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
                animator.SetInteger("TowerBuilt", 1);
                Debug.Log("Contruct the simple type tchuwtchuw");
                break;
            case "fast":
                animator.SetInteger("TowerBuilt", 2);
                Debug.Log("Contruct the fast type KATCHAU");
                break;
            case "strong":
                animator.SetInteger("TowerBuilt", 3);
                Debug.Log("Contruct the strong type KATBUUUM");
                break;
            default:
                animator.SetInteger("TowerBuilt", 0);
                break;
        }


        animator.SetTrigger("Close");

    }
}
