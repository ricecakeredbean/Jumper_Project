using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMoveController : UnitMoveController<EnemyController>
{
    private Color originColor;
    private float chargedTime;

    private void Start()
    {
        originColor = unit.UnitSpriteRendere.color;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        unit.UnitSpriteRendere.color = Color.Lerp(originColor, Color.red, chargedTime);
    }

    protected override Vector2 GetMoveDirection()
    {
        Vector2 result = Vector2.zero;
        if (unit.TrySearchPlayer(out PlayerController player))
        {
            chargedTime += Time.deltaTime;
            result = player.transform.position - transform.position;
        }
        else
        {
            chargedTime -= Time.deltaTime;
        }
        return result.normalized;
    }

    protected override bool IsCanMove()
    {
        return MoveDIr != Vector2.zero && chargedTime >= 1;
    }

    protected override void UnitMove()
    {
        unit.UnitRigidibody.AddForce(MoveDIr * unit.Speed, ForceMode2D.Impulse);
        chargedTime = 0;
    }

    protected override void AnimationUpdate()
    {
    }
}
