using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    private SpriteRenderer sprite;
    private BoxCollider2D box;
    private Color originColor;

    private float canTime;

    private float coolTime;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        originColor = sprite.color;

    }

    private void Update()
    {
        if (CoolTimeCount())
        {
            sprite.color = originColor;
            box.enabled = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerStat player = collision.collider.GetComponent<PlayerStat>();
        if (player)
        {
            if (!Wating())
            {
                box.enabled = false;
                sprite.color = new Color(0, 0, 0, 0);
                coolTime = 5;
            }
            else
            {
                sprite.color = new Color(canTime, canTime, canTime);
            }
        }
    }

    private bool Wating()
    {
        canTime += Time.deltaTime * 0.75f;
        return canTime < 1f;
    }

    private bool CoolTimeCount()
    {
        coolTime -= Time.deltaTime * 0.75f;
        return coolTime <= 0;
    }
}
