using System;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    private int _turns;

    public Action NoMovesLeft;
    public Action<int> ChangedCountTurns;

    private void Start()
    {
        _turns = 5;
        ChangedCountTurns?.Invoke(_turns);
    }

    public void IncreaseTurns(Match match)
    {
        _turns += match.positions.Count-1;
        ChangedCountTurns?.Invoke(_turns);
    }
    
    public void DecreaseTurns()
    {
        _turns--;
        ChangedCountTurns?.Invoke(_turns);
        if(_turns == 0)
            NoMovesLeft?.Invoke();
    }
}
