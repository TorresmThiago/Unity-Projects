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

    public IEnumerator PanelMatch(bool result)
    {
        if (result)
        {
            yield return new WaitForSeconds(1f);
            _animator.SetTrigger("Match");
        }
        else
        {
            yield return new WaitForSeconds(.75f);
            _animator.SetTrigger("Wrong");
        }
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
