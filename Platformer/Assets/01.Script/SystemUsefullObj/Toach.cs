using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toach : MonoBehaviour
{
    private void FixedUpdate()
    {
        RaycastHit2D[] rayHit = Physics2D.CircleCastAll(transform.position, 3.5f, Vector2.zero);
        for (int i = 0; i < rayHit.Length; i++)
        {
            Ghost ghost = rayHit[i].collider.GetComponent<Ghost>();
            if(ghost)
            {
                ghost.Die();
            }
        }
    }
}
