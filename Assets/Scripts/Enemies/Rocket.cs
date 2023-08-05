using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float RocketSpeed = 1f;
    public float RotationSpeed = 1f;

    private Transform _targetTransform;

    private void Start()
    {
        _targetTransform = FindObjectOfType<PlayerMove>().transform;
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * RocketSpeed;
        Vector3 toAim = _targetTransform.position - transform.position;
        Quaternion targetQuaternion = Quaternion.LookRotation(toAim, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, RotationSpeed * Time.deltaTime);

    }
}
