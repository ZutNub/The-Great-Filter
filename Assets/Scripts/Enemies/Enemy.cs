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

    [SerializeField]
    private float attackCooldown = 3;

    [SerializeField]
    private int attackDamage = 10;

    private float cooldown = 0;

    private bool isRotating = false;
    private bool isCirclingTarget = false;

    private int _health;

    private Point currentPoint;

    private void Start()
    {
        List<Vector3> points = new List<Vector3>();
        points.Add(new Vector3(0, -6, 0));
        points.Add(new Vector3(-6, 0, 0));
        points.Add(new Vector3(0, 6, 0));
        points.Add(new Vector3(6, 0, 0));

        path = new Path(points);

        //TODO Delete everything above later
        currentPoint = path.getFirstPoint();
        cooldown = attackCooldown;
    }

    private void Update()
    {
        if (!isCirclingTarget)
        {
            if (!isRotating)
            {
                Move();
            }
            Rotate(currentPoint.Value);
        }
        else 
        {
            Move();
            //TODO
            //Rotate(path.Target.getPosition());
            Rotate(Vector3.zero);
        }
        cooldown -= Time.deltaTime;
        if (isCirclingTarget && cooldown <= 0) 
        {
            AttackTarget();
            cooldown = attackCooldown;
        }
    }

    public void Move()
    {
        if (Vector3.Distance(transform.position, currentPoint.Value) <= distanceTreshhold)
        {
            if (!isCirclingTarget && currentPoint.Equals(path.getLastPoint()))
            {
                isCirclingTarget = true;
                path = new Path(OrbitCalculator.calculateSinOverCircle(Vector3.zero), true);
                currentPoint = path.getFirstPoint();
            }
            else 
            {
                currentPoint = currentPoint.Next;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.Value, movementSpeed * Time.deltaTime);
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
        //TODO
        //Rotate Turret
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

    public void AttackTarget()
    {
        //path.Target.TakeDamage(attackDamage);
        //TODO
        //Turret animation
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

    public Vector3 getPosition()
    {
        return transform.position;
    }
}