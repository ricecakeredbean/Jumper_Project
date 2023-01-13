using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStat player = collision.collider.GetComponent<PlayerStat>();
        if (player)
        {
            Vector3 dir = player.transform.position - transform.position;
            Debug.Log(dir);
            player.GetComponent<Rigidbody2D>().AddForce(dir * 3.25f,ForceMode2D.Impulse);
        }
    }
}
