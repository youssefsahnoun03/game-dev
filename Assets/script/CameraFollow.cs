using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 2f, -6f);
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = player.position + player.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        transform.LookAt(player.position + Vector3.up * 2f);
    }
}