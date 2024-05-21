using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitController
{
    [SerializeField] private float jumpPower;
    public float JumpPower => jumpPower;
}
