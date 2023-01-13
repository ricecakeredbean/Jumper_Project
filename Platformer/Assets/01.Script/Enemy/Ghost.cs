using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    private GameObject target;
    private Coroutine cor;

    protected override float moveSpeed => 0.5f;

    private void FixedUpdate()
    {
        if (FindPlayer())
        {
            if (cor != null)
            {
                StopCoroutine(cor);
            }
            cor = StartCoroutine(Move());
        }
    }

    private bool FindPlayer()
    {
        RaycastHit2D[] circleHit = Physics2D.CircleCastAll(transform.position, 4.5f, Vector2.down);
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

    public void Die()
    {
        if(cor != null)
        {
            StopCoroutine(cor);
        }    
        StartCoroutine(Death_Cor());
    }

    IEnumerator Move()
    {
        while (true)
        {
            for (float t = 0; t < 1; t += Time.deltaTime*moveSpeed)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, t);
                yield return null;
            }
        }
    }

    IEnumerator Death_Cor()
    {
        for (float t = 1; t >= 0; t-=Time.deltaTime)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, t);
        }
        Destroy(gameObject);
        yield return null;
    }

    protected override EnemyType GetEnemyType()
    {
        return EnemyType.ghost;
    }
}
