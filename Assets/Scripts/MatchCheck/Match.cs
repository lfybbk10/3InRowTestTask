using System.Collections.Generic;

public class Match
{
    public List<Position> positions { get;}

    public Match()
    {
        positions = new List<Position>();
    }

    public void AddPosition(Position position)
    {
        positions.Add(position);
    }

    public bool isCorrectMatch()
    {
        return positions.Count >= 3;
    }

    public bool ContainsPosition(Position position)
    {
        return positions.Contains(position);
    }
}
