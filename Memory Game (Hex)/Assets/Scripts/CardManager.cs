using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    public List<Card> compareList;

    public TextMeshProUGUI panelText;
    public Image panelBackground;

    public GameObject grid;

    public LevelDificulty level;

    [SerializeField]
    private Card cardPrefab;
    private ColorLibrary colorLibrary;

    private List<string> colorList;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        colorLibrary = new ColorLibrary();
        colorList = colorLibrary.GetColorList(level);
        InstantiateCardGrid(colorList);
    }

    private void InstantiateCardGrid(List<string> colorList, int gridHeight = 5, int gridWidth = 4)
    {
        int colorListIndex = 0;
        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                Transform parent = grid.transform.Find("CardRow " + i);
                Card card = Instantiate(cardPrefab, new Vector3(i, j, 0), Quaternion.identity, parent);
                string[] cardInfo = colorList[colorListIndex].Split("#");
                card.cardType = cardInfo[0] == "C" ? CardType.Color : CardType.Hex;
                card.hexCode = "#" + cardInfo[1];
                colorListIndex++;
            }
        }
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
                bool result = CompareElements();
                StartCoroutine(Panel.Instance.PanelMatch(result));

                if (result)
                    StartCoroutine(cardElement.FadeAway());
                else
                    StartCoroutine(cardElement.FlipBack());
            }

            compareList.Clear();
        }

    }
}
