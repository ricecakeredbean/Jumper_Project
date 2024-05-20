using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Vector2 center;

    [Header("XPos")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [Header("YPos")]
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private float height;
    private float width;

    private void Update()
    {
        Vector3 targetTrans = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, targetTrans,Time.deltaTime * 2f);
        transform.position = ClampCamera();
    }

    private Vector3 ClampCamera()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
        float startX = minX - width;
        float endX = maxX - width;
        float startY = minY - height;
        float endY = maxY - height;
        float x = Mathf.Clamp(transform.position.x, center.x - startX, center.x + endX);
        float y = Mathf.Clamp(transform.position.y, center.y - startY, center.y + endY);
        return new Vector3(x, y,-10);
    }
}
