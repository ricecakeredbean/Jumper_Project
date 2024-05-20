using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMoveController : UnitMoveController<EnemyController>
{
    protected override Vector2 GetMoveDirection()
    {
        Vector2 result = Vector2.zero;
        Collider2D[] hitInfos = Physics2D.OverlapCircleAll(transform.position, unitController.SearchDis);
        foreach (var hitInfo in hitInfos)
        {
            if (hitInfo.TryGetComponent(out PlayerController playerController))
            {
                result = transform.position - playerController.transform.position;
                return result.normalized;
            }
        }
        return result;
    }

    protected override bool IsCanMove()
    {
        return MoveDir != Vector2.zero && IsGround() && IsWall();
    }

    private bool IsGround()
    {
        RaycastHit2D rayHit = Physics2D.Raycast((Vector2)transform.position + MoveDir * unitController.Speed, Vector2.down, 0.2f, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            return false;
        }

        return rayHit;
    }

    private bool IsWall()
    {
        RaycastHit2D rayHit = Physics2D.Raycast((Vector2)transform.position + Vector2.up + MoveDir * unitController.Speed, Vector2.one, 0.2f, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            return false;
        }
        return true;
    }

    protected override void UnitMove()
    {
        transform.Translate(MoveDir * unitController.Speed * Time.deltaTime);
    }
}