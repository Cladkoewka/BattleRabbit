using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public float Speed = 6;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform playertransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (playertransform.position - transform.position).normalized;
        _rigidbody.velocity = toPlayer * Speed;


    }

}
