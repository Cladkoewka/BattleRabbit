using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleCapsule : MonoBehaviour
{
    public int GunIndex = 1;
    public int BulletsCount = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerArmory>())
            {
                other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(GunIndex, BulletsCount);
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
