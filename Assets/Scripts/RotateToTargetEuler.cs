using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    public Vector3 LeftAngle;
    public Vector3 RightAngle;
    public float RotationSpeed = 5;

    private Vector3 _targetAngle;

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetAngle), Time.deltaTime * RotationSpeed);
    }

    public void SetLeftAngleAsTarget()
    {
        _targetAngle = LeftAngle;
    }

    public void SetRighttAngleAsTarget()
    {
        _targetAngle = RightAngle;
    }
}
