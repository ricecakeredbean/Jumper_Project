using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UnitMoveController<T> : MonoBehaviour where T : UnitController
{
    protected T unit;

    public Vector2 MoveDIr { get; protected set; }
    public bool IsJumping { get; protected set; }

    protected virtual void Awake()
    {
        unit = GetComponent<T>();
    }

    protected virtual void FixedUpdate()
    {
        MoveDIr = GetMoveDirection();
        AnimationUpdate();
        if (IsCanMove())
        {
            unit.UnitSpriteRendere.flipX = MoveDIr.x < 0;
            UnitMove();
        }
    }

    protected abstract void AnimationUpdate();

    protected abstract bool IsCanMove();

    protected abstract Vector2 GetMoveDirection();

    protected abstract void UnitMove();
}
