
using System;
using System.Collections;
using UnityEngine;

public class GameGridHandler : MonoBehaviour
{
    private GameGrid _gameGrid;
    private MatchChecker _matchChecker;

    private void Start()
    {
        _matchChecker = GetComponent<MatchChecker>();
        _gameGrid = GetComponent<GameGrid>();
    }

    public void OnBallClicked(Ball ball)
    {
        DeleteBall(ball);
        StartCoroutine(DeleteAllMatches());
    }

    private IEnumerator DeleteAllMatches()
    {
        yield return new WaitForSeconds(2);

        Match match = _matchChecker.FindMatch();
        while (match!=null)
        {
            foreach (var position in match.positions)
            {
                DeleteBall(_gameGrid.balls[position.i,position.j]);
            }
            yield return new WaitForSeconds(1);
            match = _matchChecker.FindMatch();
        }

        _gameGrid.SpawnNewBalls();
    }

    private void DeleteBall(Ball ball)
    {
        if(ball==null)
            return;
        
        for (int i = 0; i < _gameGrid.balls.GetLength(0); i++)
        {
            for (int j = 0; j < _gameGrid.balls.GetLength(1); j++)
            {
                if (_gameGrid.balls[i, j] == ball)
                {
                    MoveToDelBallPos(i,j);
                    Destroy(_gameGrid.balls[i, j].gameObject);
                    _gameGrid.balls.DelElemAndMoveUpperElems(i, j);
                }
            }
        }

    }

    private void MoveToDelBallPos(int i, int j)
    {
        int currIndex = 0;
        while (currIndex < i)
        {
            Ball currBall = _gameGrid.balls[currIndex, j];
            Ball nextBall = _gameGrid.balls[currIndex+1, j];
            
            if(currBall!=null && nextBall!=null)
                currBall.transform.Translate(Vector3.down * Vector2.Distance(currBall.transform.position, nextBall.transform.position), Space.World);
            
            currIndex++;
        }
    }
    
    
}
