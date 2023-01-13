using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStat player = collision.collider.GetComponent<PlayerStat>();
        if(player != null)
        {
            //StageManager.Instance.StageReset();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStat player = collision.GetComponent<PlayerStat>();
        if (player != null)
        {
            //StageManager.Instance.StageReset();
        }
    }
}
