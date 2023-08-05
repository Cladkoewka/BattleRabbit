using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public float Speed = 3f;
    public float TimeToReachSpeed = 1f;
    private Rigidbody _rigidbody;
    private Transform _playerTransform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (toPlayer * Speed - _rigidbody.velocity) / TimeToReachSpeed; // F=ma
        _rigidbody.AddForce(force);
    }
}
