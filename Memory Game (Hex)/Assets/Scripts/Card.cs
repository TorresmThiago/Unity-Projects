using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Sprite cardBack;
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

        _image.sprite = null;
    }

    public void Hide()
    {
        _text.text = "";
        _image.color = new Color(1, 1, 1, 1);
        _image.sprite = cardBack;
    }

    public IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(1f);
        _animator.SetTrigger("Match");
        yield return new WaitForSeconds(.75f);
        Debug.Log("Destroy?");
        Destroy(gameObject);
    }

    public IEnumerator FlipBack()
    {
        yield return new WaitForSeconds(.75f);
        _animator.SetTrigger("Flip");
    }

    public enum CardType
    {
        Hex,
        Color
    }

}