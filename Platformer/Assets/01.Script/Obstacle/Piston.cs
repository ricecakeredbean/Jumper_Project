using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PistonType
{
    Auto,
    Target
}


public class Piston : MonoBehaviour
{
    [SerializeField] private PistonType pistonType;
    [SerializeField] private float speed;
    [SerializeField] private GameObject HitObj;

    private Vector3 originTrans;

    private void Start()
    {
        originTrans = transform.position;
        switch (pistonType)
        {
            case PistonType.Auto:
                StartCoroutine(AutoAttack_Cor());
                break;
            case PistonType.Target:
                break;
        }
    }

    private bool BackOrigin()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed * 0.5f);
        return 0.5f >= Vector3.Distance(transform.position, originTrans);
    }

    IEnumerator AutoAttack_Cor()
    {
        while (true)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, 1.25f, LayerMask.GetMask("Platform"));
            transform.Translate(Vector2.down * Time.deltaTime * speed);
            if (rayHit)
            {
                yield return new WaitForSeconds(2f);
                while (!BackOrigin())
                {
                    HitObj.SetActive(false);
                    yield return null;
                }
            }
            else
            {
                HitObj.SetActive(true);
            }
            yield return null;
        }
    }

}
