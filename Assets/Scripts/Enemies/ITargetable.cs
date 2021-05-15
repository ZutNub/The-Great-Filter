using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable
{
    int Health { get; }

    void TakeDamage(int damage);

    void OnDamageTaken();

    void OnDeath();

    Vector3 getPosition();
}
