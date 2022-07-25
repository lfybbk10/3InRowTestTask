using System;
using UnityEngine;


public class ScoreRecordsPresenter : MonoBehaviour
{
    [SerializeField] private ScoreRecordView _scoreRecordViewPrefab;
    [SerializeField] private GameObject _header;
    private ScoreRecordsHandler _scoreRecordsHandler;
    private Canvas _mainCanvas;

    private float _offsetViews = 100;

    private void Awake()
    {
        _scoreRecordsHandler = FindObjectOfType<ScoreRecordsHandler>();
        _mainCanvas = FindObjectOfType<Canvas>();
        
        GenerateScoreRecordViews();
    }

    private void GenerateScoreRecordViews()
    {
        float heightView = _scoreRecordViewPrefab.GetComponent<RectTransform>().rect.height;

        for (int i = 0; i < _scoreRecordsHandler.ScoreRecords.Count; i++)
        {
            ScoreRecord scoreRecord = _scoreRecordsHandler.ScoreRecords[i];
            ScoreRecordView scoreRecordView = Instantiate(_scoreRecordViewPrefab,
                new Vector3(0, _header.GetComponent<RectTransform>().localPosition.y - (i+1) * (heightView + _offsetViews)), Quaternion.identity);
            scoreRecordView.transform.SetParent(_mainCanvas.transform,false);

            scoreRecordView.Number = (i + 1).ToString();
            scoreRecordView.Score = scoreRecord.Score.ToString();
            scoreRecordView.Date = scoreRecord.Date.ToString().Split(' ')[0];
            scoreRecordView.UpdateTextFields();

            if (_scoreRecordsHandler.NewScoreRecord == scoreRecord)
                StartCoroutine(scoreRecordView.StartFlickerAnimation());
        }
    }
}
