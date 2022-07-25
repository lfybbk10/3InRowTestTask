﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecordsHandler : MonoBehaviour
{
    private List<ScoreRecord> _scoreRecords = new List<ScoreRecord>();
    public ScoreRecord NewScoreRecord { get; set; }

    public List<ScoreRecord> ScoreRecords
    {
        get
        {
            return _scoreRecords;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(_scoreRecords.Count==0)
            loadFromFile();
    }

    public bool handleCurrentRecord(ScoreRecord scoreRecord)
    {
        if (_scoreRecords.Count < 5)
        {
            _scoreRecords.Add(scoreRecord);
            NewScoreRecord = scoreRecord;
            _scoreRecords.Sort();
            _scoreRecords.Reverse();
            saveToFile();
            return true;
        }
        
        int index = _scoreRecords.FindIndex(x => scoreRecord.CompareTo(x) == 1);
        if (index != -1)
        {
            _scoreRecords.Insert(index,scoreRecord);
            NewScoreRecord = scoreRecord;
            _scoreRecords.RemoveAt(_scoreRecords.Count-1);
            saveToFile();
            return true;
        }
        
        return false;
        
    }
    
    private void loadFromFile()
    {
        _scoreRecords = CSVTools.LoadRecordsFromFile(Application.persistentDataPath+"/scoreRecords.csv");
        
        _scoreRecords.Sort();
        _scoreRecords.Reverse();
    }

    private void saveToFile()
    {
        CSVTools.SaveRecordsToFile(_scoreRecords, Application.persistentDataPath+"/scoreRecords.csv");
    }
}
