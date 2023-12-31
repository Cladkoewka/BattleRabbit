using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}
public class RopeGun : MonoBehaviour
{
    public Transform Spawn;
    public float Speed;
    public Hook Hook; 
    public SpringJoint SpringJoint;
    public Transform RopeStart;
    public RopeState CurrentRopeState;
    public RopeRenderer RopeRenderer;
    public PlayerMove PlayerMove;

    private float _length;

   

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }
        if (CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);
            if (distance > 20) 
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disabled;
                RopeRenderer.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CurrentRopeState == RopeState.Active && !PlayerMove.IsGrounded)
            {
                PlayerMove.Jump();
            }
            DestroySpring();
        }
        if (CurrentRopeState == RopeState.Fly || CurrentRopeState == RopeState.Active)
        {
            RopeRenderer.Draw(RopeStart.position, Hook.transform.position, _length);
        }
    }

    private void Shot()
    {
        _length = 1;
        if (SpringJoint)
        {
            Destroy(SpringJoint);
        }

        Hook.gameObject.SetActive(true);

        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity = Spawn.forward * Speed;

        CurrentRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (SpringJoint == null)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.anchor = RopeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = 100f;
            SpringJoint.damper = 5f;

            _length = Vector3.Distance(RopeStart.position, Hook.transform.position);
            SpringJoint.maxDistance = _length;
            CurrentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if (SpringJoint)
        {
            Destroy(SpringJoint);
            CurrentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
            RopeRenderer.Hide();
        }
    }
}
