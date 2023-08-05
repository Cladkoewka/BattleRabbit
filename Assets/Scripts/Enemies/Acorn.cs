using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public Vector3 Velocity;

    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().AddTorque(Random.Range(1, 10f), Random.Range(1, 10f), Random.Range(1, 10f));
    }
}
