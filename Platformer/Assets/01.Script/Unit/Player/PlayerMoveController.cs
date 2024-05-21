using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : UnitMoveController<PlayerController>
{
    private bool IsClim;

    private bool IsWallJump;

    private void Climwall()
    {
        Vector2 velocity = unitController.UnitRigidibody.velocity;
        unitController.UnitRigidibody.velocity = new Vector2(velocity.x, velocity.y * 0.8f);
    }

    private bool WallJump()
    {
        Vector2 jumpDir = new Vector2(unitController.JumpPower * -MoveDIr.x, unitController.UnitRigidibody.gravityScale * unitController.JumpPower * 2f);
        unitController.UnitRigidibody.AddForce(jumpDir, ForceMode2D.Impulse);
        return true;
    }

    private bool IsGround()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position, -transform.up, 1.5f, LayerMask.GetMask("Platform"));
        return hitGround;
    }

    private bool IsWall()
    {
        RaycastHit2D hitWall = Physics2D.Raycast(transform.position + new Vector3(MoveDIr.x, -1.25f), Vector3.down * unitController.UnitRigidibody.gravityScale, 0.25f, LayerMask.GetMask("Platform"));
        return hitWall;
    }

    private void UnitJump()
    {
        unitController.UnitRigidibody.AddForce(transform.up * unitController.JumpPower, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (InputManager.Instance.IsJump)
        {
            if (IsClim)
            {
                WallJump();
                return;
            }
            if (!IsGround())
            {
                return;
            }
            UnitJump();
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        IsClim = !IsGround() && IsWall();
        if (IsClim)
        {
            Climwall();
        }
    }

    protected override Vector2 GetMoveDirection()
    {
        return InputManager.Instance.MoveVec;
    }

    protected override bool IsCanMove()
    {
        return MoveDIr != Vector2.zero;
    }

    protected override void UnitMove()
    {
        transform.Translate(MoveDIr * Time.deltaTime * unitController.Speed);
    }
}
