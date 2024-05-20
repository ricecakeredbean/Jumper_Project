using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    public static readonly int RunHash = Animator.StringToHash("IsRun");
    public static readonly int JumpHash = Animator.StringToHash("IsJump");
    public static readonly int ClimHash = Animator.StringToHash("IsClim");
    public static readonly int LandHash = Animator.StringToHash("IsGround");


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnim(int hashCode,bool value)
    {
        animator.SetBool(hashCode, value);
    }
}
