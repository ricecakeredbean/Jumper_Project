using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : UnitMoveController<PlayerController>
{
    //private PlayerController playerController;

    //private PlayerAnimationController anim;

    //private Vector2 moveVec;

    //private void Awake()
    //{
    //    playerController = GetComponent<PlayerController>();
    //    anim = GetComponent<PlayerAnimationController>();
    //}

    //private void Update()
    //{

    //}


    //private bool P_Move()
    //{
    //    transform.Translate(PlayerStat.Instance.moveSpeed * Time.deltaTime * moveVec);
    //    return true;
    //}

    //private bool P_Jump()
    //{
    //    rigid.AddForce(Vector2.up * PlayerStat.Instance.JumpPower * rigid.gravityScale, ForceMode2D.Impulse);
    //    return true;
    //}

    //private bool IsGround()
    //{
    //    RaycastHit2D hitGround = Physics2D.Raycast(transform.position, Vector3.down * rigid.gravityScale, 1.5f, LayerMask.GetMask("Platform"));
    //    if (hitGround.collider == null)
    //    {
    //        return false;
    //    }
    //    return hitGround.collider.CompareTag("Platform");
    //}

    //private bool IsWall()
    //{
    //    RaycastHit2D hitWall = Physics2D.Raycast(transform.position + new Vector3(moveVec.x, -1.25f), Vector3.down * rigid.gravityScale, 0.25f, LayerMask.GetMask("Platform"));
    //    if (hitWall.collider == null)
    //    {
    //        return false;
    //    }
    //    return true;
    //}

    //private bool ClimWall()
    //{
    //    rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * 0.9f);
    //    return true;
    //}

    //private bool WallJump()
    //{
    //    rigid.AddForce((0.5f * PlayerStat.Instance.JumpPower * (Vector2.up * rigid.gravityScale)) + (moveVec * -0.75f) * PlayerStat.Instance.JumpPower, ForceMode2D.Impulse);
    //    transform.position += Vector3.up * 0.3f * rigid.gravityScale;
    //    return true;
    //}
    //private bool AttackEnemy()
    //{
    //    RaycastHit2D hitGround = Physics2D.Raycast(transform.position + (Vector3.down * 1.5f + Vector3.left) * rigid.gravityScale, Vector3.right, 2f, LayerMask.GetMask("Enemy"));
    //    if (hitGround.collider != null)
    //    {
    //        Destroy(hitGround.collider.gameObject);
    //        return true;
    //    }
    //    return false;
    //}
    protected override Vector2 GetMoveDirection()
    {
        return InputManager.Instance.MoveVec;
    }

    protected override bool IsCanMove()
    {
        return MoveDir != Vector2.zero;
    }

    protected override void UnitMove()
    {
    }
}
