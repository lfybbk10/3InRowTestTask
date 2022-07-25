using System;

public class ScoreRecord : IComparable
{
    public int Score { get;}
    public DateTime Date { get;}
    
    public ScoreRecord(){}

    public ScoreRecord(int score, DateTime date)
    {
        Score = score;
        Date = date;
    }

    public int CompareTo(object obj)
    {
        if (Score < ((ScoreRecord) obj).Score)
            return -1;
        else if (Score > ((ScoreRecord) obj).Score)
            return 1;
        else
        {
            if (Date < ((ScoreRecord) obj).Date)
                return 1;
            else if (Date > ((ScoreRecord) obj).Date)
                return -1;
            else
                return 0;
        }

    }
}
