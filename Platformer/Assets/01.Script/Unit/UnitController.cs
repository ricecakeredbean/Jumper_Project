using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] private float speed;
    public float Speed { get { return speed; } protected set { speed = value; } }

    public Rigidbody2D UnitRigidibody { get; private set; }

    public SpriteRenderer UnitSpriteRendere { get; private set; }

    private void Awake()
    {
        UnitRigidibody = GetComponent<Rigidbody2D>();
        UnitSpriteRendere = GetComponent<SpriteRenderer>();
    }
}
