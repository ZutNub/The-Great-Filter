using System.Collections.Generic;
using UnityEngine;

public class Path
{
    public Vector2Int CurrentPoint { get; private set; }

    private readonly Stack<Vector2Int> points;
    public ITargetable Target { get; private set; }

    public Path(Stack<Vector2Int> points)
    {
        this.points = points;
        CurrentPoint = points.Pop();
    }

    public Vector2Int NextPoint()
    {
        if (points.Count == 0)
        {
            return Vector2Int.zero;
        }

        CurrentPoint = points.Pop();
        return CurrentPoint;
    }
}