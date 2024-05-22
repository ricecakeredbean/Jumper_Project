using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimatorController : MonoBehaviour
{
    public Animator UnitAnimator { get; protected set; }

    private void Awake()
    {
        UnitAnimator = GetComponent<Animator>();
    }

    public void SetAnimation(int stateCode, bool value)
    {
        UnitAnimator.SetBool(stateCode, value);
    }

    public void SetAnimation(int stateCode)
    {
        UnitAnimator.SetTrigger(stateCode);
    }

    public void SetAnimation(int stateCode, float value)
    {
        UnitAnimator.SetFloat(stateCode, value);
    }

    public void SetAnimation(int stateCode, int value)
    {
        UnitAnimator.SetInteger(stateCode, value);
    }
}
