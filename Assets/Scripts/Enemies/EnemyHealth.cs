using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Health;

    public UnityEvent OnTakeDamage;
    public UnityEvent OnEnemyDie;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
        OnTakeDamage?.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
        OnEnemyDie.Invoke();
    }
}
