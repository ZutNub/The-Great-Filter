using System.Collections.Generic;
using UnityEngine;

public class Path
{
    public Vector3Int CurrentPoint { get; private set; }

    private readonly Stack<Vector3Int> points;
    public ITargetable Target { get; private set; }

    public Path(Stack<Vector3Int> points)
    {
        this.points = points;
        CurrentPoint = points.Pop();
    }

    public Vector3Int NextPoint()
    {
        if (points.Count == 0)
        {
            return Vector3Int.zero;
        }

        CurrentPoint = points.Pop();
        return CurrentPoint;
    }
}