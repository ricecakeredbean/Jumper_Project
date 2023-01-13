using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : Enemy
{
    private Rigidbody2D rigid;

    private GameObject target;

    private Animator anim;

    private Color originColor;

    private float chargedTime;

    private float coolTime;

    protected override float moveSpeed => 0.5f;

    protected override void Awake()
    {
        base.Awake();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        originColor = sprite.color;
    }

    private void FixedUpdate()
    {
        if (Cooling())
        {
            if (FindPlayer())
            {
                sprite.color = new Color(chargedTime, 0, 0);
                if (ChargedDash())
                {
                    if (Dash())
                    {
                        sprite.color = originColor;
                        anim.SetBool("isDash", true);
                        chargedTime = 0;
                        coolTime = 2.25f;
                    }
                }
                else
                {
                    anim.SetBool("isDash", false);
                }
            }
            else
            {
                anim.SetBool("isDash", false);
                if (UnChargedDash())
                {
                    sprite.color = new Color(chargedTime, 0, 0);
                }
                else
                {
                    sprite.color = originColor;
                }
            }
        }
    }

    private bool FindPlayer()
    {
        RaycastHit2D[] circleHit = Physics2D.CircleCastAll(transform.position, 3.5f, Vector2.down);
        for (int i = 0; i < circleHit.Length; i++)
        {
            PlayerStat player = circleHit[i].collider.GetComponent<PlayerStat>();
            if (player != null)
            {
                target = player.gameObject;
                return player;
            }
        }
        return false;
    }

    private bool ChargedDash()
    {
        if (chargedTime > 1f)
        {
            return true;
        }
        chargedTime += Time.deltaTime * 0.8f;
        return false;
    }

    private bool Dash()
    {
        rigid.AddForce((target.transform.position - transform.position) * 2.5f, ForceMode2D.Impulse);
        return true;
    }

    private bool UnChargedDash()
    {
        if (chargedTime > 0)
        {
            chargedTime -= Time.deltaTime;
            return true;
        }
        return false;
    }

    private bool Cooling()
    {
        coolTime -= Time.deltaTime;
        return coolTime <= 0;
    }

    protected override EnemyType GetEnemyType()
    {
        return EnemyType.dino;
    }
}
