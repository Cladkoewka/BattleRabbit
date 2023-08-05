using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public float MaxSpeed;
    public float CrouchLerpSpeed;
    public bool IsGrounded;
    public Transform BodyTransform;

    private Rigidbody _rigidbody;
    private int _jumpFrameCounter;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S) ||  Input.GetKey(KeyCode.LeftControl) || !IsGrounded)
        {
            BodyTransform.localScale = Vector3.Lerp(BodyTransform.localScale, new Vector3(1, 0.6f, 1), CrouchLerpSpeed * Time.deltaTime);
        }
        else
        {
            BodyTransform.localScale = Vector3.Lerp(BodyTransform.localScale, new Vector3(1, 1, 1), CrouchLerpSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded)
            {
                Jump();
            }
        }

    }

    public void Jump()
    {
        _rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }


    private void FixedUpdate()
    {
        float speedMultilier = 1;

        if (!IsGrounded)
        {
            speedMultilier = 0.15f;

            if (_rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultilier = 0;
            }
            else if (_rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultilier = 0;
            }
        }

        

        _rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultilier, 0, 0, ForceMode.VelocityChange);

        if (IsGrounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15);
        }

        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2)
        {
            _rigidbody.freezeRotation = false;
            _rigidbody.AddRelativeTorque(0, 0, 10, ForceMode.VelocityChange);
        }
    }

    
    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle <= 45)
            {
                IsGrounded = true;
                _rigidbody.freezeRotation = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
}
 