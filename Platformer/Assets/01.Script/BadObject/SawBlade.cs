using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    [SerializeField] private List<Vector3> pointList = new();
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        StartCoroutine(MoveCor());
    }

    IEnumerator MoveCor()
    {
        while (true)
        {
            for (int i = 0; i < pointList.Count - 1; i++)
            {
                for (float t = 0; t < 1; t += Time.deltaTime * moveSpeed)
                {
                    transform.position = Vector2.Lerp(pointList[i], pointList[i + 1], t);
                    yield return null;
                }
                transform.position = pointList[i + 1];
            }
            for (int i = pointList.Count - 1; i > 0; i--)
            {
                for (float t = 0; t < 1; t += Time.deltaTime * moveSpeed)
                {
                    transform.position = Vector2.Lerp(pointList[i], pointList[i - 1], t);
                    yield return null;
                }
                transform.position = pointList[i - 1];
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStat player = collision.GetComponent<PlayerStat>();
        if(player != null)
        {
            //StageManager.Instance.StageReset();
        }
    }
}
