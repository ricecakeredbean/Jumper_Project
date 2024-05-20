using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnGravity : MonoBehaviour
{
    private SpriteRenderer sprite;
    private CircleCollider2D circle;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            player.transform.localScale = new Vector2(player.transform.localScale.x, player.transform.localScale.y * -1);
            player.UnitRigidibody.gravityScale *= -1;
            StartCoroutine(Dissables());
        }
    }

    IEnumerator Dissables()
    {
        circle.enabled = false;
        sprite.color = new Color(sprite.color.a, sprite.color.g, sprite.color.b, 0);
        for (float t = 0; t < 1; t += Time.deltaTime * 0.3f)
        {
            sprite.color = new Color(sprite.color.a, sprite.color.g, sprite.color.b, t);
            yield return null;
        }
        circle.enabled = true;
        yield return null;
    }
}
