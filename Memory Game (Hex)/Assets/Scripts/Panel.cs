using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Panel : MonoBehaviour
{
    public static Panel Instance;

    private TextMeshProUGUI _text;
    private Animator _animator;
    private Image _background;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _animator = GetComponent<Animator>();
        _background = GetComponent<Image>();
    }

    public void AddElementToPanel(Card card)
    {
        if (ColorUtility.TryParseHtmlString(card.hexCode, out Color color))
        {
            if (card.cardType == Card.CardType.Hex)
                _text.text = card.hexCode;
            else
                _background.color = color;
        }
    }
}
