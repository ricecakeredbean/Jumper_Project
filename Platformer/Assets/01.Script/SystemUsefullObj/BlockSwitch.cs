using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSwitch : MonoSingleTon<BlockSwitch>
{
    public bool IsOn { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStat player = collision.GetComponent<PlayerStat>();
        if(player)
        {
            IsOn = !IsOn;
        }
    }
}
