using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    public Gun[] Guns;

    public int CurrentGunIndex = 0;

    private void Start()
    {
        TakeGunByIndex(CurrentGunIndex);
    }

    public void TakeGunByIndex(int index)
    {
        CurrentGunIndex = index;
        for (int i = 0; i < Guns.Length; i++)
        {
            if (i == index)
            {
                Guns[i].Activate();
            }
            else
            {
                Guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int bulletsCount)
    {
        Guns[gunIndex].AddBullets(bulletsCount);
    }
}
