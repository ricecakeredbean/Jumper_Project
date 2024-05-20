using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnGravityField : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            player.UnitRigidibody.gravityScale *= -1;
            player.transform.localScale = new Vector2(player.transform.localScale.x,-player.transform.localScale.y);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            player.UnitRigidibody.gravityScale *= -1;
            player.transform.localScale = new Vector2(player.transform.localScale.x, -player.transform.localScale.y);
        }
    }
}
