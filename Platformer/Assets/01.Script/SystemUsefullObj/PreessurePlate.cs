using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreessurePlate : MonoBehaviour
{
    [SerializeField] private Text countingText;
    [SerializeField] private int maxObj;
    [SerializeField] private Vector2 originPos;

    Coroutine cor;

    private int nowObj;

    List<GameObject> objectsLists = new();

    private void Awake()
    {
        //box = GetComponent<BoxCollider2D>();
        countingText.text = $"{maxObj}";
    }

    private void Start()
    {
        originPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!objectsLists.Contains(collision.gameObject))
        {
            objectsLists.Add(collision.gameObject);
        }
        nowObj = maxObj - objectsLists.Count;
        if (nowObj <= 0)
        {
            nowObj = 0;
            if (cor != null)
            {
                StopCoroutine(cor);
            }
            cor = StartCoroutine(Heavy());
        }
        countingText.text = $"{nowObj}";
    }

    IEnumerator OnCollisionExit2D(Collision2D collision)
    {
        yield return new WaitForSeconds(0.35f);
        objectsLists.Remove(collision.gameObject);
        nowObj = maxObj - objectsLists.Count;
        if (nowObj <= 0)
        {
            nowObj = 0;
        }
        else
        {
            if (cor != null)
            {
                StopCoroutine(cor);
            }
            cor = StartCoroutine(Lite());
        }
        countingText.text = $"{nowObj}";
    }

    IEnumerator Heavy()
    {
        while (true)
        {
            transform.parent.transform.Translate(Vector2.down * Time.deltaTime * 1.5f);
            yield return null;
        }
    }

    IEnumerator Lite()
    {
        while (0.15f < Vector2.Distance(transform.parent.position, originPos))
        {
            Vector2 dir = (originPos - (Vector2)transform.parent.position).normalized;
            transform.parent.transform.Translate(dir * Time.deltaTime * 1.5f);
            yield return null;
        }
        transform.parent.position = originPos;
    }
}
