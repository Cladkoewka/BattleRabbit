using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    public Animator Animator;
    public float AttackPeriod = 5f;
    public string TriggerName = "Attack";

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= AttackPeriod)
        {
            _timer = 0;
            Animator.SetTrigger(TriggerName);
        }
    }
}
