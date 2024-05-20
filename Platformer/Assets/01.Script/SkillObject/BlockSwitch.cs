using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSwitch : Singleton<BlockSwitch>
{
    public bool IsOn { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            IsOn = !IsOn;
        }
    }
}
