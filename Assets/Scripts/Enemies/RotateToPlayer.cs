using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public Vector3 LeftAngle;
    public Vector3 RightAngle;
    public float RotationSpeed = 5f;

    private Transform _playerTransform;
    private Vector3 _targetAngle;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        if (_playerTransform.position.x >= transform.position.x)
        {
            _targetAngle = RightAngle;
        }
        else
        {
            _targetAngle = LeftAngle;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetAngle), Time.deltaTime * RotationSpeed);
    }
}
