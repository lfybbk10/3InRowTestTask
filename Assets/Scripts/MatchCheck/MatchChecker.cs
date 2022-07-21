using System;
using UnityEngine;

public class MatchChecker : MonoBehaviour
{
    private GameGrid _gameGrid;

    private void Start()
    {
        _gameGrid = GetComponent<GameGrid>();
    }

    public Match FindMatch(int i, int j)
    {
        Ball[,] balls = _gameGrid.balls;
        
        Match matchRightOfElem = findMatchOnHorizontalSegment(i, j, balls.GetLength(1) - 1);
        if (matchRightOfElem != null && matchRightOfElem.ContainsPosition(new Position(i,j)))
            return matchRightOfElem;
        Match matchLeftOfElem = findMatchOnHorizontalSegment(i, j, 0);
        if (matchLeftOfElem != null && matchLeftOfElem.ContainsPosition(new Position(i,j)))
            return matchLeftOfElem;
        
        Match matchUpOfElem = findMatchOnVerticalSegment(j, i, 0);
        if (matchUpOfElem != null && matchUpOfElem.ContainsPosition(new Position(i,j)))
            return matchUpOfElem;
        
        Match matchDownOfElem = findMatchOnVerticalSegment(j, i, balls.GetLength(0) - 1);
        if (matchDownOfElem != null && matchDownOfElem.ContainsPosition(new Position(i,j)) )
            return matchDownOfElem;

        return null;

    }

    public Match FindMatch()
    {
        for (int i = 0; i < _gameGrid.balls.GetLength(0); i++)
        {
            Match match = findMatchOnHorizontalSegment(i, 0, _gameGrid.balls.GetLength(1) - 1);
            if (match != null)
                return match;
        }
        
        for (int j = 0; j < _gameGrid.balls.GetLength(1); j++)
        {
            Match match = findMatchOnVerticalSegment(j, 0, _gameGrid.balls.GetLength(0) - 1);
            if (match != null)
                return match;
        }

        return null;
    }

    private Match findMatchOnHorizontalSegment(int i, int startJ, int endJ)
    {
        Ball[,] balls = _gameGrid.balls;
        Match currMatch = new Match();
        
        BallType currentBallType = 0;
        if (balls[i, startJ] != null)
        {
            currMatch.AddPosition(new Position(i,startJ));
            currentBallType = balls[i,startJ].BallType;
        }

        if (endJ >= startJ)
        {
            for (int j = startJ + 1; j <= endJ; j++)
            {
                if(balls[i,j]!=null && balls[i,j].BallType == currentBallType)
                    currMatch.AddPosition(new Position(i,j));
                else
                {
                    if (currMatch.isCorrectMatch())
                    {
                        return currMatch;
                    }
                    
                    currMatch = new Match();
                    if (balls[i, j] != null)
                    {
                        currentBallType = balls[i,j].BallType;
                        currMatch.AddPosition(new Position(i,j));
                    }
                }
            }
        }
        else
        {
            for (int j = startJ - 1; j >= 0; j--)
            {
                if(balls[i,j]!=null && balls[i,j].BallType == currentBallType)
                    currMatch.AddPosition(new Position(i,j));
                else
                {
                    if (currMatch.isCorrectMatch())
                    {
                        return currMatch;
                    }
                    
                    currMatch = new Match();
                    if (balls[i, j] != null)
                    {
                        currentBallType = balls[i,j].BallType;
                        currMatch.AddPosition(new Position(i,j));
                    }
                }
            }
        }
        
        if (currMatch.isCorrectMatch())
        {
            return currMatch;
        }

        return null;
    }
    
    private Match findMatchOnVerticalSegment(int j, int startI, int endI)
    {
        Ball[,] balls = _gameGrid.balls;
        Match currMatch = new Match();
        
        BallType currentBallType = 0;
        if (balls[startI, j] != null)
        {
            currMatch.AddPosition(new Position(startI, j));
            currentBallType = balls[startI, j].BallType;
        }

        if (endI >= startI)
        {
            for (int i = startI + 1; i <= endI; i++)
            {
                if(balls[i,j]!=null && balls[i,j].BallType == currentBallType)
                    currMatch.AddPosition(new Position(i,j));
                else
                {
                    if (currMatch.isCorrectMatch())
                    {
                        return currMatch;
                    }
                    
                    currMatch = new Match();
                    if (balls[i, j] != null)
                    {
                        currentBallType = balls[i,j].BallType;
                        currMatch.AddPosition(new Position(i,j));
                    }
                }
            }
        }
        else
        {
            for (int i = startI - 1; i >= 0; i--)
            {
                if(balls[i,j]!=null && balls[i,j].BallType == currentBallType)
                    currMatch.AddPosition(new Position(i,j));
                else
                {
                    if (currMatch.isCorrectMatch())
                    {
                        return currMatch;
                    }
                    
                    currMatch = new Match();
                    if (balls[i, j] != null)
                    {
                        currentBallType = balls[i,j].BallType;
                        currMatch.AddPosition(new Position(i,j));
                    }
                }
            }
        }
        
        if (currMatch.isCorrectMatch())
        {
            return currMatch;
        }

        return null;
    }
    
    
}
