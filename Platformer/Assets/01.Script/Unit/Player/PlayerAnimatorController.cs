using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : UnitAnimatorController
{
    public static readonly int RunCode = Animator.StringToHash("IsRun");
    public static readonly int JumpCode = Animator.StringToHash("IsJump");
    public static readonly int ClimCode = Animator.StringToHash("IsClim");
}
