using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float cameraDistZ = 20.0f;
    public float cameraDistY = 20.0f;
    public float cameraDistX = 20.0f;

    private void Update()
    {
        Vector3 pos = player.transform.position;
        pos.z += cameraDistZ;
        pos.y += cameraDistY;
        pos.x += cameraDistX;
        transform.position = pos;
    }
}
