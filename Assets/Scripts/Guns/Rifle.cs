using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rifle : Gun
{
    public int BulletsCount;
    public TMP_Text BulletsText;
    public PlayerArmory PlayerArmory;


    public override void Shot()
    {
        base.Shot();
        BulletsCount -= 1;
        UpdateText();
        if (BulletsCount <= 0)
        {
            PlayerArmory.TakeGunByIndex(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        Debug.Log(BulletsText.text);
        BulletsText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        BulletsText.enabled = false;
    }

    public override void AddBullets(int bulletsCount)
    {
        base.AddBullets(bulletsCount);
        BulletsCount += bulletsCount;
        UpdateText();
        if (PlayerArmory != null)
        {
            PlayerArmory.TakeGunByIndex(1);
        }
    }

    private void UpdateText()
    {
        BulletsText.text = "Bullets:" + BulletsCount.ToString();
    }
}
