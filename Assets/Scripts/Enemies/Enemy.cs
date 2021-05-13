using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITargetable
{
    private Path path;

    [SerializeField]
    private float distanceTreshhold = 0.2f;

    [SerializeField]
    private float movementSpeed = 1f;

    [SerializeField]
    private float rotationTreshhold = 15;

    [SerializeField]
    private float rotationSpeed = 1f;

    [SerializeField]
    private float rotationOffset = 180;

    private bool isRotating = false;

    private int _health;

    private void Start()
    {
        Stack<Vector3Int> points = new Stack<Vector3Int>();
        points.Push(new Vector3Int(0, 4, 0));
        points.Push(new Vector3Int(0, -4, 0));
        points.Push(new Vector3Int(-10, -2, 0));
        points.Push(new Vector3Int(1, 4, 0));
        points.Push(new Vector3Int(6, 8, 0));
        points.Push(new Vector3Int(-7, -2, 0));
        points.Push(new Vector3Int(5, 2, 0));

        path = new Path(points);
    }

    private void Update()
    {
        if (!isRotating)
        {
            Move();
        }
        Rotate(path.CurrentPoint);
    }

    public void Move()
    {
        if (Vector3.Distance(transform.position, path.CurrentPoint) <= distanceTreshhold)
        {
            path.NextPoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, path.CurrentPoint, movementSpeed * Time.deltaTime);
    }

    public void Rotate(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - rotationOffset;

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(rotation.eulerAngles, transform.rotation.eulerAngles) <= rotationTreshhold)
        {
            isRotating = false;
        }
        else
        {
            isRotating = true;
        }
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
}