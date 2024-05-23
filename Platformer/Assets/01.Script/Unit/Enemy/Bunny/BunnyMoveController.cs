using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMoveController : UnitMoveController<EnemyController>
{
    private Vector2 currentDir = Vector2.right;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay((Vector2)transform.position + MoveDIr, Vector2.down);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay((Vector2)transform.position + Vector2.up*0.5f, MoveDIr);
    }

    protected override void FixedUpdate()
    {
        if (!IsGround() || IsWall())
        {
            currentDir *= -1;
        }
        base.FixedUpdate();
        Debug.Log(currentDir);
    }

    protected override Vector2 GetMoveDirection()
    {
        return currentDir;
    }

    protected override bool IsCanMove()
    {
        return MoveDIr != Vector2.zero;
    }

    private bool IsGround()//자기 아래 땅이 아닌 진행방향의 앞에 땅 검사
    {
        RaycastHit2D rayHit = Physics2D.Raycast((Vector2)transform.position + MoveDIr, Vector2.down, 0.2f, LayerMask.GetMask("Platform"));
        return rayHit;
    }

    private bool IsWall()
    {
        RaycastHit2D rayHit = Physics2D.Raycast((Vector2)transform.position + Vector2.up*0.5f, MoveDIr, 1.25f, LayerMask.GetMask("Platform"));
        return rayHit;
    }



    protected override void UnitMove()
    {
        transform.Translate(MoveDIr * unit.Speed * Time.deltaTime);
    }

    protected override void AnimationUpdate()
    {
        return;//애니메이션 없음
    }
}
