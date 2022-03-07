using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittabble
{
    [field: SerializeField]
    public int Health { get; set; } = 2;

    private bool Dead;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (Dead == false)
        {
            Health-= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                OnDie?.Invoke();
                Dead = true;
                StartCoroutine(DeathCoroutine());
            }
        }
    }

    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
