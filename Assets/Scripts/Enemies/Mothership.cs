using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : Enemy
{
    [SerializeField]
    private GameObject locustPrefab;

    [SerializeField]
    private float summonCooldown = 5;

    private float sCooldown = 0;

    void Start()
    {
        List<Vector3> points = new List<Vector3>();
        points.Add(new Vector3(0, -10, 0));
        path = new Path(points);

        //TODO set Path correctly
        //TODO move start and update from enemy into own methods

        animator = GetComponent<EnemyAnimator>();
        animator.Init();
        animator.PlayIdleAnimation();
        currentPoint = path.getFirstPoint();
        cooldown = attackCooldown;
        sCooldown = summonCooldown;
    }

    void Update()
    {
        sCooldown -= Time.deltaTime;
        if (sCooldown <= 0)
        {
            SummonEnemy();
            sCooldown = summonCooldown;
        }
    }

    private void SummonEnemy() 
    {
        GameObject locust = GameObject.Instantiate(locustPrefab, this.transform.position, Quaternion.identity, null);
    }
}
