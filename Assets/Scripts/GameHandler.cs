
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private TurnHandler _turnHandler;
    [SerializeField] private ScoreRecordsHandler _scoreRecordsHandler;

    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private TurnView _turnView;
    private void Awake()
    {
        _scoreHandler.Received += _scoreView.UpdateScoreText;
        _turnHandler.ChangedCountTurns += _turnView.UpdateTurnText;
        _turnHandler.NoMovesLeft += OnGameOver;
    }

    private void OnDisable()
    {
        _scoreHandler.Received -= _scoreView.UpdateScoreText;
        _turnHandler.ChangedCountTurns -= _turnView.UpdateTurnText;
        _turnHandler.NoMovesLeft -= OnGameOver;
    }

    private void OnGameOver()
    {
        OnDisable();
        
        _scoreRecordsHandler.handleCurrentRecord(new ScoreRecord(_scoreHandler.Score, DateTime.Now));
        SceneManager.LoadScene(1);
    }
}
