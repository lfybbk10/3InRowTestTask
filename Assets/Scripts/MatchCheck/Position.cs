public class Position
{
    public int i { get;}
    public int j { get;}

    public Position(int i, int j)
    {
        this.i = i;
        this.j = j;
    }

    public override bool Equals(object obj)
    {
        return obj is Position && ((Position) obj).i == i && ((Position) obj).j == j;
    }
}
