using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnGravityField : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStat player = collision.GetComponent<PlayerStat>();
        if (player != null)
        {
            player.GetComponent<Rigidbody2D>().gravityScale *= -1;
            player.transform.localScale = new Vector2(player.transform.localScale.x,-player.transform.localScale.y);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerStat player = collision.GetComponent<PlayerStat>();
        if (player != null)
        {
            player.GetComponent<Rigidbody2D>().gravityScale *= -1;
            player.transform.localScale = new Vector2(player.transform.localScale.x, -player.transform.localScale.y);
        }
    }
}
