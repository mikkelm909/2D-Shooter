using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : EnemyAttack
{
    public override void Attack(int damage)
    {
        if (waitBeforeNextAttack == false)
        {
            var hittable = GetTarget().GetComponent<IHittabble>();
            hittable?.GetHit(damage, gameObject);
            StartCoroutine(WaitBeforeAttackCoroutine());
        }
    }
}
