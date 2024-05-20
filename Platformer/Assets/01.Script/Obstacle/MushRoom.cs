using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            Vector3 dir = player.transform.position - transform.position;
            player.UnitRigidibody.AddForce(dir * 3.25f, ForceMode2D.Impulse);
        }
    }
}
