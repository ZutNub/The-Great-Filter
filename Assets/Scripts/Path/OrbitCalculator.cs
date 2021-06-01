using System.Collections.Generic;
using UnityEngine;

public class OrbitCalculator
{
    public static List<Vector3> CalculateSinOverCircle(Vector3 origin, float radius = 8, float amplitude = 1, float cycles = 10, float phaseShift = 0, float stepsize = 0.05f)
    {
        List<Vector3> points = new List<Vector3>();

        for (float i = 0; i < 2 * Mathf.PI; i += stepsize)
        {
            float x = (radius + amplitude * Mathf.Sin(cycles * i + phaseShift)) * Mathf.Cos(i) + origin.x;
            float y = (radius + amplitude * Mathf.Sin(cycles * i + phaseShift)) * Mathf.Sin(i) + origin.y;
            points.Add(new Vector3(x, y, 0));
        }

        return points;
    }

    public static List<Vector3> CalculateEllipse(Vector3 origin, float scaleX = 5, float scaleY = 8, float phaseShiftX = 0, float phaseShiftY = 0, float stepsize = 0.05f)
    {
        List<Vector3> points = new List<Vector3>();

        for (float i = 0; i < 2 * Mathf.PI; i += stepsize)
        {
            float x = scaleX * Mathf.Cos(i + phaseShiftX) + origin.x;
            float y = scaleY * Mathf.Sin(i + phaseShiftY) + origin.y;
            points.Add(new Vector3(x, y, 0));
        }

        return points;
    }
}