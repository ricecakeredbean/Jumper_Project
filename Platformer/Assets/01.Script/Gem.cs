using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Gem : MonoBehaviour
{
    [SerializeField] private Vector2[] BeziorPoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStat player = collision.GetComponent<PlayerStat>();
        if (player)
        {
            StartCoroutine(Bezior_Cor());
        }
    }

    private Vector3 Bezior(Vector2[] poss, float t)
    {
        for (int i = 0; i < poss.Length - 1; i++)
        {
            for (int j = i; j >= 0; j--)
            {
                poss[j] = Vector2.Lerp(poss[j], poss[j + 1], t);
            }
        }
        return poss[0];
    }

    IEnumerator Bezior_Cor()
    {
        BeziorPoss[0] = transform.position;
        BeziorPoss[1] = Camera.main.ScreenToWorldPoint(new Vector2(1000,1020));
        BeziorPoss[2] = Camera.main.ScreenToWorldPoint(new Vector2(1420,1020));
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            transform.position = Bezior(BeziorPoss.ToArray(), t);
            yield return null;
        }
        StageManager.Instance.AddScore(1000);
        Destroy(gameObject,0.25f);
    }
}
