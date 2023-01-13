using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStat player = collision.GetComponent<PlayerStat>();
        if(player)
        {
            
        }
    }
}
