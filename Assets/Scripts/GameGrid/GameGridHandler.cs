
using System;
using System.Collections;
using UnityEngine;

public class GameGridHandler : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private TurnHandler _turnHandler;
    
    private GameGrid _gameGrid;
    private MatchChecker _matchChecker;
    
    private void Awake()
    {
        _matchChecker = GetComponent<MatchChecker>();
        _gameGrid = GetComponent<GameGrid>();
    }

    public void OnBallClicked(Ball ball)
    {
        RemoveClickListeners();
        StartCoroutine(OnBallClickedCoroutine(ball));
    }

    private IEnumerator OnBallClickedCoroutine(Ball ball)
    {
        StartCoroutine(DeleteBall(ball));
        yield return new WaitForSeconds(2);
        StartCoroutine(DeleteAllMatches());
    }

    private IEnumerator DeleteAllMatches()
    {

        Match match = _matchChecker.FindMatch();
        while (match!=null)
        {
            _scoreHandler.ReceiveScore(match);
            _turnHandler.IncreaseTurns(match);
            
            foreach (var position in match.positions)
            {
                StartCoroutine(DeleteBall(_gameGrid.balls[position.i,position.j]));
            }
            
            yield return new WaitForSeconds(1.7f);
            match = _matchChecker.FindMatch();
        }
        
        _turnHandler.DecreaseTurns();
        _gameGrid.SpawnNewBalls();
    }

    private IEnumerator DeleteBall(Ball ball)
    {
        if(ball==null)
           yield break;
        
        for (int i = 0; i < _gameGrid.balls.GetLength(0); i++)
        {
            for (int j = 0; j < _gameGrid.balls.GetLength(1); j++)
            {
                if (_gameGrid.balls[i, j] == ball)
                {
                    StartCoroutine(_gameGrid.balls[i, j].ToZeroScale(1));
                    yield return new WaitForSeconds(1.5f);
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
    
    public void AddClickListeners()
    {
        for (int i = 0; i < _gameGrid.balls.GetLength(0); i++)
        {
            for (int j = 0; j < _gameGrid.balls.GetLength(1); j++)
            {
                if (_gameGrid.balls[i, j] != null)
                {
                    _gameGrid.balls[i, j].Clicked += OnBallClicked;
                }
            }
        }
    }
    
    public void RemoveClickListeners()
    {
        for (int i = 0; i < _gameGrid.balls.GetLength(0); i++)
        {
            for (int j = 0; j < _gameGrid.balls.GetLength(1); j++)
            {
                if (_gameGrid.balls[i, j] != null)
                {
                    _gameGrid.balls[i, j].Clicked -= OnBallClicked;
                }
            }
        }
    }
    
    
}
