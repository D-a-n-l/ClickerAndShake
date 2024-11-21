using UnityEngine;
using DG.Tweening;
using TMPro;

public class AnimatedText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private string _maskText;

    [Space(5)]
    [SerializeField]
    private float _offsetY;

    [Min(0.001f)]
    [SerializeField]
    private float _duration;

    private void OnEnable()
    {
        StartAnimation();
    }

    public void Init(int value)
    {
        _text.text = $"{_maskText}{value}";
    }

    public void StartAnimation()
    {
        DOTween.Sequence()
            .Append(transform.DOMoveY(transform.position.y + _offsetY, _duration))
            .Append(_text.DOFade(0, _duration))
            .OnComplete(() => Destroy(gameObject));
    }
}