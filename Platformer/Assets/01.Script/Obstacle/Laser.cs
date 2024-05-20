using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    private GameObject laser2;

    private void Update()
    {
        if(laser2 != null)
        {
            Destroy(laser2);
        }
        RaycastHit2D[] rayHit = Physics2D.RaycastAll(transform.position, transform.right, 200);

        for (int i = 0; i < rayHit.Length; i++)
        {
            if (rayHit[i].collider.CompareTag("Platform"))
            {
                laser2 = Instantiate(laser);
                laser2.transform.position = Vector3.Lerp(transform.position, rayHit[i].point, 0.5f);
                laser2.transform.rotation = transform.rotation;
                laser2.transform.localScale = new Vector2(Vector2.Distance(rayHit[i].point, transform.position), laser2.transform.localScale.y);
                break;
            }
        }
    }

    private void Start()
    {
    }
}
