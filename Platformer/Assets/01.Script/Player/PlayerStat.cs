using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoSingleTon<PlayerStat>
{
    public int Life { get; private set; } = 3;
    public float moveSpeed { get; private set; } = 2.5f;
    public float JumpPower { get; private set; } = 6f;

    public Vector2 Pos { get; private set; }

    private void Start()
    {
        LifeSet();
    }

    private void Update()
    {
        Pos = transform.position;
    }

    private void LifeSet()
    {
       //Life = DataManager.Instance.StageInfo().SaveData.haveLife;
    }

    public void JumpPowerUp(float xPer)
    {
        JumpPower *= xPer;
    }
}
