using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DestroyManager : MonoBehaviour
{
    private static List<int> destroyList = new();
    private int id;

    private void Start()
    {
        id = gameObject.GetInstanceID();
        if(destroyList.Contains(id))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        destroyList.Add(id);
    }
}
