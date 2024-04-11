using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleTon<InputManager>
{
    private KeyCode resetKey = KeyCode.R;

    public int ClampJump { get; private set; }
    public int ClampRun { get; private set; }

    public bool IsJump { get; private set; }

    public Vector2 MoveVec { get; private set; }

    public void SetClamp(int clampJump, int clampRun)
    {
        ClampJump = clampJump;
        ClampRun = clampRun;
    }

    private void Start()
    {
        SetClamp(40, 40);
    }

    private void Update()
    {
        Horizon();
        Jump();
        InputZero();
        if (Input.GetKeyDown(resetKey))
        {
            //StageManager.Instance.StageReset();
        }
    }

    private void Horizon()
    {
        if (ClampRun == 0)
        {
            MoveVec = Vector2.zero;
            return;
        }
        float h = Input.GetAxisRaw("Horizontal");
        MoveVec = new Vector2(h, 0);
        if (Input.GetButtonDown("Horizontal"))
        {

            ClampRun -= 1;
        }
    }

    private void Jump()
    {
        if (ClampJump == 0)
        {
            IsJump = false;
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            IsJump = true;
            ClampJump -= 1;
        }
        else
        {
            IsJump = false;
        }
    }

    private void InputZero()
    {
        if (ClampJump == 0 && ClampRun == 0)
        {
            //StageManager.Instance.StageReset();
        }
    }
}
