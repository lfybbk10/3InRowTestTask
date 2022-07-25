using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class CSVTools
{
    public static void SaveRecordsToFile(List<ScoreRecord> scoreRecords, String path)
    {
        List<String> strings = new List<string>();
        foreach (var scoreRecord in scoreRecords)
        {
            strings.Add(scoreRecord.Score+","+scoreRecord.Date);
        }
        File.Delete(path);
        File.WriteAllLines(path,strings);
    }

    public static List<ScoreRecord> LoadRecordsFromFile(String path)
    {
        List<ScoreRecord> scoreRecords = new List<ScoreRecord>();
        List<String> strings = File.ReadAllLines(path).ToList();
        foreach (var str in strings)
        {
            String[] splittedStr = str.Split(',');
            scoreRecords.Add(new ScoreRecord(int.Parse(splittedStr[0]),DateTime.Parse(splittedStr[1])));
        }

        return scoreRecords;

    }
}
