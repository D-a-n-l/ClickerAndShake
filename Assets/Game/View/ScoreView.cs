using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    public void Refresh(int value)
    {
        _text.text = value.ToString();
    }
}