using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : UnitController
{
    [SerializeField] private float searchDis;
    public float SearchDis { get; protected set; }

}
