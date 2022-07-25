using System;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScoreText(int score)
    {
        _text.SetText($"Очки: {score}");
    }
}
