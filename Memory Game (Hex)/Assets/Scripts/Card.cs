using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Sprite cardImage;
    public Sprite cardBackground;
    public CardType cardType;
    public string hexCode;

    private TextMeshProUGUI _text;
    private Animator _animator;
    private Image _image;
    private bool showing;

    void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _animator = GetComponent<Animator>();
        _image = GetComponent<Image>();
        showing = false;
    }

    public void CardClick()
    {
        if (!CardManager.Instance.compareList.Contains(this))
            _animator.SetTrigger("Flip");
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

        CardManager.Instance.AddElementToCompare(this);
        Panel.Instance.AddElementToPanel(this);
        _image.sprite = cardBackground;
    }

    public void Hide()
    {
        _text.text = "";
        _image.color = new Color(1, 1, 1, 1);
        _image.sprite = cardImage;
    }

    public IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(1f);
        _animator.SetTrigger("Match");
        yield return new WaitForSeconds(.75f);
        _image.enabled = false;
        _text.enabled = false;
    }

    public IEnumerator FlipBack()
    {
        yield return new WaitForSeconds(.75f);
        _animator.SetTrigger("Flip");
    }

}

public enum CardType
{
    Hex,
    Color
}