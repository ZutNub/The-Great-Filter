using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public Vector3 Value { get; set; }
    public Point Next { get; set; }
    public Point Previous { get; set; }

    public Point(Vector3 value) 
    {
        Value = value;
    }

    public Point(Vector3 value, Point next, Point previous) 
    {
        Value = value;
        Next = next;
        Previous = previous;
    }
}
