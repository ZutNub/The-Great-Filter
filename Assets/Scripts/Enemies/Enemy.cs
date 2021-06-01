using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITargetable
{
    protected Path path;
    protected EnemyAnimator animator;

    [SerializeField]
    protected float distanceTreshhold = 0.2f;

    [SerializeField]
    protected float movementSpeed = 1f;

    [SerializeField]
    protected float rotationTreshhold = 15;

    [SerializeField]
    protected float rotationSpeed = 1f;

    [SerializeField]
    protected float rotationOffset = 180;

    [SerializeField]
    protected float attackCooldown = 3;

    [SerializeField]
    protected int attackDamage = 10;

    [SerializeField]
    protected int _health;

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

    protected float cooldown = 0;

    protected bool isRotating = false;
    protected bool isCirclingTarget = false;

    protected Point currentPoint;

    private void Start()
    {
        List<Vector3> points = new List<Vector3>();
        points.Add(new Vector3(0, -10, 0));
        points.Add(new Vector3(-10, 0, 0));
        points.Add(new Vector3(0, 10, 0));
        points.Add(new Vector3(10, 0, 0));
        GameObject target = GameObject.Find("Mutterschiff");
        ITargetable taget2 = target.GetComponent<Enemy>();
        path = new Path(points, taget2);

        //TODO Delete everything above later
        animator = GetComponent<EnemyAnimator>();
        animator.Init();
        animator.PlayIdleAnimation();
        currentPoint = path.GetFirstPoint();
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
            Rotate(path.Target.getPosition());
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
            if (!isCirclingTarget && currentPoint.Equals(path.GetLastPoint()) && path.Target != null)
            {
                isCirclingTarget = true;
                path = new Path(OrbitCalculator.CalculateSinOverCircle(path.Target.getPosition()), path.Target, true);
                currentPoint = path.GetFirstPoint();
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
        if (Health > 0)
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
    }

    public void AttackTarget()
    {
        if (path.Target != null)
        {
            path.Target.TakeDamage(attackDamage);
        }
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
        animator.PlayDeathAnimation();
        //TODO
        //Play dying animation, make dying sound, trigger point score/ wincondition
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }
}