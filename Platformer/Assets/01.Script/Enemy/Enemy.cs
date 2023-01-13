using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    bunny,
    dino,
    ghost
}


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;

    protected SpriteRenderer sprite;

    protected virtual void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    protected abstract float moveSpeed { get; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStat playerStat = collision.gameObject.GetComponent<PlayerStat>();
        if (playerStat != null)
        {
            //StageManager.Instance.StageReset();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStat playerStat = collision.GetComponent<PlayerStat>();
        if (playerStat != null)
        {
            //StageManager.Instance.StageReset();
        }
    }

    protected abstract EnemyType GetEnemyType();
}
