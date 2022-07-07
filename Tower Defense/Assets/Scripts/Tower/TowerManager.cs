using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public List<Tower> towerList;

    private Animator animator;
    private int towerSelected;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ConstructTowerAnimation(string towerType)
    {
        switch (towerType)
        {
            case "simple":
                towerSelected = 1;
                break;
            case "fast":
                towerSelected = 2;
                break;
            case "strong":
                towerSelected = 3;
                break;
            default:
                towerSelected = 0;
                break;
        }

        animator.SetInteger("TowerBuilt", towerSelected);
        animator.SetTrigger("Close");

    }

    public void InstantiateTower()
    {
        Debug.Log("Instantiate meeeeee");
        Instantiate(towerList[towerSelected - 1], transform.position, transform.rotation, transform);
    }
}
