using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : UnitController
{
    [SerializeField] private float searchDis;
    public float SearchDis => searchDis;


    public bool TrySearchPlayer(out PlayerController player)
    {
        player = null;
        Collider2D[] hitInfos = Physics2D.OverlapCircleAll(transform.position, SearchDis);
        foreach (var hitInfo in hitInfos)
        {
            if (hitInfo.TryGetComponent(out PlayerController playerController))
            {
                player = playerController;
            }
        }
        return player != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchDis);
    }
}
