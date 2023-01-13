using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : Enemy
{
    private Vector2 moveVec = Vector2.left;

    protected override float moveSpeed { get => 1;}

    private void FixedUpdate()
    {
        if (IsGround())
        {
            if (IsWall())
            {
                moveVec *= -1;
                sprite.flipX = moveVec.x < Vector2.zero.x;
            }
            else
            {
                transform.Translate(moveSpeed * Time.deltaTime * moveVec);
            }
        }
        else
        {
            moveVec *= -1;
            sprite.flipX = moveVec.x < Vector2.zero.x;
        }
    }

    private bool IsGround()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position + (Vector3)moveVec * moveSpeed, Vector2.down, 0.2f, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            return false;
        }

        return rayHit;
    }
    private bool IsWall()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position + Vector3.up + (Vector3)moveVec * moveSpeed, Vector2.one, 0.2f, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            return false;
        }
        return true;
    }

    protected override EnemyType GetEnemyType()
    {
        return EnemyType.bunny;
    }
}
