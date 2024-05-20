using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum BlockType
{
    Red,
    Blue
}

[RequireComponent(typeof(BoxCollider2D))]
public class OnOffBlock : MonoBehaviour
{
    [SerializeField] private BlockType blockType;

    private SpriteRenderer sprite;
    private BoxCollider2D box;

    private Action OnAction;
    private Action OffAction;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        switch (blockType)
        {
            case BlockType.Red:
                sprite.color = Color.red;
                OnAction += () => Enable();
                OffAction += () => Disable();
                break;
            case BlockType.Blue:
                sprite.color = Color.blue;
                OnAction += () => Disable();
                OffAction += () => Enable();
                break;
        }
    }

    private void FixedUpdate()
    {
        if (BlockSwitch.Instance.IsOn)
        {
            OnAction.Invoke();
        }
        else
        {
            OffAction.Invoke();
        }
    }

    private void Disable()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
        box.enabled = false;
    }

    private void Enable()
    {
        box.enabled = true;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
    }
}