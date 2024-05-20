using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitMoveController<T> : MonoBehaviour where T : UnitController
{
    protected T unitController;

    public Vector2 MoveDir { get; protected set; }

    protected virtual void FixedUpdate()
    {
        MoveDir = GetMoveDirection();
        if (IsCanMove())
        {
            unitController.UnitSpriteRendere.flipX = MoveDir.x < 0;
            UnitMove();
        }
    }

    protected abstract bool IsCanMove();

    protected abstract Vector2 GetMoveDirection();

    protected abstract void UnitMove();
}
