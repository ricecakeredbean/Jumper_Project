using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Image[] lifes;

    [SerializeField] private Text leftMoveText;
    [SerializeField] private Text leftJumpText;

    [SerializeField] private Text time;
    [SerializeField] private Text score;

    private void Update()
    {
        ClampText();
        LifeUi();
        TimeText();
        ScoreText();
    }
    private void LifeUi()
    {
        //for (int i = 0; i < lifes.Length; i++)
        //{
        //    lifes[i].enabled = false;
        //}
        //for (int i = 0; i < PlayerStat.Instance.Life; i++)
        //{
        //    lifes[i].enabled = true;
        //}
    }

    private void ClampText()
    {
        leftJumpText.text = $"³²ÀºÈ½¼ö : {InputManager.Instance.ClampJump}";
        leftMoveText.text = $"³²ÀºÈ½¼ö : {InputManager.Instance.ClampRun}";
    }

    private void TimeText()
    {
        time.text = $"Time : {StageManager.Instance.Sec:F2}";
    }

    private void ScoreText()
    {
        score.text = $"Score : {StageManager.Instance.Score:000,000,000;}";
    }
}
