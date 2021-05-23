using System.Collections.Generic;
using UnityEngine;

public class Path
{
    private readonly List<Point> points;
    public ITargetable Target { get; private set; }

    public Path(List<Point> points)
    {
        this.points = points;
    }

    public Path(List<Vector3> points, bool circular = false)
    {
        this.points = Vector3ListToPointList(points, circular);
    }

    public Path(List<Point> points, ITargetable target)
    {
        this.points = points;
        Target = target;
    }

    public Path(List<Vector3> points, ITargetable target, bool circular = false)
    {
        this.points = Vector3ListToPointList(points, circular);
        Target = target;
    }

    public Point getFirstPoint()
    {
        return points[0];
    }

    public Point getLastPoint()
    {
        return points[points.Count - 1];
    }

    private List<Point> Vector3ListToPointList(List<Vector3> vectors, bool circular)
    {
        List<Point> points = new List<Point>();
        for (int i = 0; i < vectors.Count; i++)
        {
            Point p = new Point(vectors[i]);
            if (i != 0)
            {
                p.Previous = points[i - 1];
                points[i - 1].Next = p;
            }
            points.Add(p);
        }

        if (circular)
        {
            int last = points.Count - 1;
            points[0].Previous = points[last];
            points[last].Next = points[0];
        }
        else
        {
            int last = points.Count - 1;
            points[0].Previous = points[0];
            points[last].Next = points[last];
        }

        return points;
    }
}