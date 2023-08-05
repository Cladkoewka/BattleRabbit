using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TakeDamage(1);
                other.attachedRigidbody.GetComponent<Bullet>().Die();
            }
        }
        if (DieOnAnyCollision)
        {
            if (!other.isTrigger)
            {
                EnemyHealth.Die();
            }
        }
    }
}
