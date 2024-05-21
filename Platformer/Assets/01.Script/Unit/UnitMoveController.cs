using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UnitMoveController<T> : MonoBehaviour where T : UnitController
{
    protected T unitController;

    public Vector2 MoveDIr { get; protected set; }

    protected virtual void Awake()
    {
        unitController = GetComponent<T>();
    }

    protected virtual void FixedUpdate()
    {
        MoveDIr = GetMoveDirection();
        if (IsCanMove())
        {
            unitController.UnitSpriteRendere.flipX = MoveDIr.x < 0;
            UnitMove();
        }
    }

    protected abstract bool IsCanMove();

    protected abstract Vector2 GetMoveDirection();

    protected abstract void UnitMove();
}
