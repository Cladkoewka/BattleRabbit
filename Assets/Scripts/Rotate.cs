using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 RotateSpeed;

    private void Update()
    {
        transform.Rotate(RotateSpeed * Time.deltaTime);
    }
}
