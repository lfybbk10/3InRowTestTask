using System;
using UnityEngine;


public class ScoreHandler : MonoBehaviour
{
    private int _score;
    private int defaultValueForMatch = 10;
    
    public Action<int> Received;

    public void ReceiveScore(Match match)
    {
        _score += (match.positions.Count - 2) * defaultValueForMatch;
        Received?.Invoke(_score);
    }

    public int Score
    {
        get
        {
            return _score;
        }
    }
}
