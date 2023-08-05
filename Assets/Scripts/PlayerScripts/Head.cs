using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Transform HeadTarget;
    void Update()
    {
        transform.position = HeadTarget.position;
    }
}
