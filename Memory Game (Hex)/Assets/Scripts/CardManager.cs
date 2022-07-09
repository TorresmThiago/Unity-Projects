using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    public static CardManager Instance;
    public List<Card> compareList;

    private void Awake()
    {
        Instance = this;
    }

    public bool CompareElements()
    {
        return compareList[0].hexCode == compareList[1].hexCode;
    }

    public void AddElementToCompare(Card card)
    {
        compareList.Add(card);
        if (compareList.Count == 2)
        {
            foreach (Card cardElement in compareList)
            {
                if (CompareElements())
                    StartCoroutine(cardElement.FadeAway());
                else
                    StartCoroutine(cardElement.FlipBack());
            }
            compareList.Clear();
        }

    }
}
