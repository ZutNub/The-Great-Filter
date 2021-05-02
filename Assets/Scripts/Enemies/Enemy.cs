using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITargetable
{
    private Path path;

    [SerializeField]
    private float distanceTreshhold = 0.2f;

    [SerializeField]
    private float movementSpeed = 1f;

    private int _health;

    private void Start()
    {
        Stack<Vector2Int> points = new Stack<Vector2Int>();
        points.Push(new Vector2Int(1, 2));
        points.Push(new Vector2Int(7, 0));
        points.Push(new Vector2Int(-10, -2));
        points.Push(new Vector2Int(1, 4));
        points.Push(new Vector2Int(6, 8));
        points.Push(new Vector2Int(-7, -2));
        points.Push(new Vector2Int(5, 2));

        path = new Path(points);
    }

    private void Update()
    {
        Move();
    }

    public int Health
    {
        get { return _health; }
        private set
        {
            _health = value;
            if (_health < 0)
            {
                _health = 0;
            }
        }
    }

    public void Move()
    {
        Vector2 pos = transform.position;
        if (Vector2.Distance(pos, path.CurrentPoint) <= distanceTreshhold)
        {
            path.NextPoint();
        }
        Vector3 nextPoint = new Vector3(path.CurrentPoint.x - pos.x, path.CurrentPoint.y - pos.y, 0);
        transform.Translate(nextPoint.normalized * Time.deltaTime * movementSpeed);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health > 0)
        {
            OnDamageTaken();
        }
        else
        {
            OnDeath();
        }
    }

    public void OnDamageTaken()
    {
        //TODO
        //Maybe change animation, blink red and make damage sound
    }

    public void OnDeath()
    {
        //TODO
        //Play dying animation, make dying sound, trigger point score/ wincondition
    }
}