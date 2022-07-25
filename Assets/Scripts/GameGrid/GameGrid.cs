using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private GridSizeParams _gridSizeParams;
    
    private GameGridHandler _gameGridHandler;
    private MatchChecker _matchChecker;

    public Ball[,] balls { get; set; }
    public Vector2[,] ballsPositons { get; set; }

    [SerializeField] private Ball _ballPrefab;

    private RectTransform rectTrasform;
    
    private void Awake()
    {
        rectTrasform = GetComponent<RectTransform>();
        _matchChecker = GetComponent<MatchChecker>();
        _gameGridHandler = GetComponent<GameGridHandler>();
        
        _gridSizeParams = new GridSizeParams(5, 5,rectTrasform.rect.width);

        GenerateBallsPositions();
        StartCoroutine(GenerateBallArray());
    }
    
    private void GenerateBallsPositions()
    {
        float ballWidth = _ballPrefab.GetComponent<RectTransform>().rect.width;
        ballsPositons = new Vector2[_gridSizeParams.rows,_gridSizeParams.columns];
        for (int i = 0; i < ballsPositons.GetLength(0); i++)
        {
            for (int j = 0; j < ballsPositons.GetLength(1); j++)
            {
                
                ballsPositons[i, j] = new Vector2((_gridSizeParams.cellSize - _gridSizeParams.cellOffset) * i + rectTrasform.rect.xMin + ballWidth + _gridSizeParams.cellOffset / 2f, 
                    (_gridSizeParams.cellSize - _gridSizeParams.cellOffset) * j + rectTrasform.rect.yMin + ballWidth + _gridSizeParams.cellOffset / 2f);
                
            }
        }
    }

    private IEnumerator GenerateBallArray()
    {
        yield return new WaitForSeconds(1);
        balls = new Ball[_gridSizeParams.rows,_gridSizeParams.columns];
        SpawnNewBalls();
    }

    public void SpawnNewBalls()
    {
        for (int i = 0; i < balls.GetLength(0); i++)
        {
            for (int j = 0; j < balls.GetLength(1); j++)
            {
                if (balls[i, j] == null)
                {
                    balls[i, j] = Instantiate(_ballPrefab,ballsPositons[i,j],Quaternion.identity);
                    balls[i, j].transform.SetParent(rectTrasform,false);
                    ChooseBallType(i,j);
                }
            }
        }
        
        _gameGridHandler.AddClickListeners();
    }

    private void ChooseBallType(int i, int j)
    {
        List<int> allBallTypes = new List<int>(Enum.GetNames(typeof(BallType)).Length);
        for (int k = 0; k < allBallTypes.Capacity; k++)
        {
            allBallTypes.Add(k);
        }
        allBallTypes.Shuffle();

        foreach (int intBallType in allBallTypes)
        {
            BallType ballType = (BallType)intBallType;
            balls[i, j].BallType = ballType;
            if (_matchChecker.FindMatch(i,j) == null)
            {
                return;
            }
        }
    }

}
