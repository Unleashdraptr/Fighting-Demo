using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Follow : MonoBehaviour
{
    public Transform TargetPlayer;

    //Help smooth out inputs
    public float smoothing = 0.125f;
    public float turnSpeed = 4f;

    private float DefaultYZoom = 7f;
    private float DefaultZZoom = 10f;
    private float Zoom = 0;

    private Vector3 VOffset;
    void Start()
    {
        VOffset = new Vector3(TargetPlayer.position.x, TargetPlayer.position.y + DefaultYZoom + Zoom, TargetPlayer.position.z + DefaultZZoom + Zoom);
    }
    void LateUpdate()
    {
        if (Input.GetButton("CameraLock"))
        {
            VOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * VOffset;
            VOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.left) * VOffset;

        }
        transform.position = TargetPlayer.position + VOffset;
        transform.LookAt(TargetPlayer.position);
        if (Input.GetMouseButtonDown(2))
        {
            Zoom = Input.GetAxis("Mouse ScrollWheel");
        }
    }
}


