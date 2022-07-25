
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private TurnHandler _turnHandler;
    [SerializeField] private GameButtonsHandler _gameButtonsHandler;
    private ScoreRecordsHandler _scoreRecordsHandler;

    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private TurnView _turnView;
    private void Awake()
    {
        _scoreRecordsHandler = FindObjectOfType<ScoreRecordsHandler>();
        
        _scoreHandler.Received += _scoreView.UpdateScoreText;
        _turnHandler.ChangedCountTurns += _turnView.UpdateTurnText;
        _turnHandler.NoMovesLeft += OnGameOver;
        _gameButtonsHandler.Paused += OnPause;
        _gameButtonsHandler.Resumed += OnResume;
    }

    private void OnDisable()
    {
        _scoreHandler.Received -= _scoreView.UpdateScoreText;
        _turnHandler.ChangedCountTurns -= _turnView.UpdateTurnText;
        _turnHandler.NoMovesLeft -= OnGameOver;
    }

    private void OnPause()
    {
        Time.timeScale = 0;
    }

    private void OnResume()
    {
        Time.timeScale = 1;
    }

    private void OnGameOver()
    {
        OnDisable();
        
        _scoreRecordsHandler.handleCurrentRecord(new ScoreRecord(_scoreHandler.Score, DateTime.Now));
        SceneManager.LoadScene(1);
    }
}
