using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Sprite cardBack;

    public CardType cardType;

    [SerializeField]
    private string hexCode;

    private TextMeshProUGUI _text;
    private Image _image;
    private bool showing;

    void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _image = GetComponent<Image>();
        showing = false;
    }

    public void TriggerCardAnimation()
    {
        if (showing)
            Hide();
        else
            Show();

        showing = !showing;
    }

    public void Show()
    {
        if (ColorUtility.TryParseHtmlString(hexCode, out Color color))
        {
            if (cardType == CardType.Hex)
            {
                _text.color = color;
                _text.text = hexCode;
            }

            if (cardType == CardType.Color)
            {
                _image.color = color;
            }
        }

        _image.sprite = null;
    }

    public void Hide()
    {
        _text.text = "";
        _image.color = new Color(1, 1, 1, 1);
        _image.sprite = cardBack;
    }

    public enum CardType
    {
        Hex,
        Color
    }

}