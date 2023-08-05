using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float JumpShotSpeed;
    public Gun Pistol;
    public float MaxCharge;
    public ChargeIcon ChargeIcon;

    private float _currentCharge;
    private bool _isCharged = false;

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) )
            {
                PlayerRigidbody.AddForce(-transform.forward * JumpShotSpeed, ForceMode.VelocityChange);
                Pistol.Shot();
                _isCharged=false;
                _currentCharge = 0;
                ChargeIcon.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            ChargeIcon.UpdateCharge(_currentCharge, MaxCharge);
            if (_currentCharge >= MaxCharge)
            {
                _isCharged = true;
                ChargeIcon.StopCharge();
            }
        }
    }
}
