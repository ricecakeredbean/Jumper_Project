using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public int Score { get; private set; }
    public float Sec { get; private set; }

    private int secneIndex;

    private int[] clampJump = new int[5] { 15, 10, 8, 5, 2 };
    private int[] clampRun = new int[5] { 15, 10, 7, 5, 3 };

    public bool IsLoad { get; private set; }

    private void Update()
    {
        TImeCount();
    }

    private void TImeCount()
    {
        Sec += Time.deltaTime;
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    class Data
    {
        int senceIndex;
        int score;
        float sec;

        public Data(int senceIndex, int score, float sec)
        {
            this.senceIndex = senceIndex;
            this.score = score;
            this.sec = sec;
        }
    }

}
