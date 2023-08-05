using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right,
}
public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;

    public float Speed;
    public float StopTime;

    public Direction CurrentDirection;

    public UnityEvent OnWalkingLeft;
    public UnityEvent OnWalkingRight;

    public Transform RayStart;

    private bool _isStopped = false;

    private void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }

    private void Update()
    {
        if (_isStopped) return;

        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            if (transform.position.x < LeftTarget.position.x)
            {
                CurrentDirection= Direction.Right;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                OnWalkingRight.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            if (transform.position.x > RightTarget.position.x)
            {
                CurrentDirection = Direction.Left;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                OnWalkingLeft.Invoke();
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(RayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    private void ContinueWalk()
    {
        _isStopped = false;
    }
}
