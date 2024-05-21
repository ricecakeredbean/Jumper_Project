using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMoveController : UnitMoveController<EnemyController>
{
    private Color originColor;

    private void Start()
    {
        originColor = unitController.UnitSpriteRendere.color;
    }

    protected override Vector2 GetMoveDirection()
    {
        Vector2 result = Vector2.zero;
        Collider2D[] hitInfos = Physics2D.OverlapCircleAll(transform.position,unitController.SearchDis);
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
        return MoveDIr != Vector2.zero;
    }

    protected override void UnitMove()
    {
    }
}
