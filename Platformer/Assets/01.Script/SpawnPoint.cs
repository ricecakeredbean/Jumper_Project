using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : Singleton<SpawnPoint>
{
    IEnumerator Start()
    {
        yield return null;
        //yield return new WaitUntil(() => StageManager.Instance.IsLoad);
        //PlayerStat.Instance.transform.position = transform.position+Vector3.up;
    }
}
