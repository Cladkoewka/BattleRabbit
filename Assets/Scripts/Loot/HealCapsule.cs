using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCapsule : MonoBehaviour
{
    public int CapsuleHealth = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>()) 
        {
            other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(CapsuleHealth);
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
