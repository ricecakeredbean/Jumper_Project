using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[ExecuteInEditMode]
public class Magnet : MonoBehaviour
{
    private void Update()
    {
        if(EditorApplication.isPlaying)
        {
            return;
        }
        float x = (int)(transform.position.x * 4) * 0.25f;
        float y = (int)(transform.position.y * 4) * 0.25f;

        transform.position = new Vector3(x, y);

    }
}
#endif