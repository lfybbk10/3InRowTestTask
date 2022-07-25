public class GridSizeParams
{
    public int rows { get;}
    public int columns { get;}
    public float cellSize { get;}
    public float cellOffset { get; }
    
    public GridSizeParams(int rows, int columns, float rectWidth)
    {
        this.rows = rows;
        this.columns = columns;
        cellSize = rectWidth / columns;
        cellOffset = 1f / columns;
    }
}
