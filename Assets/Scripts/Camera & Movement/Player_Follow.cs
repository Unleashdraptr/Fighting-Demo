using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Follow : MonoBehaviour
{
    //player
    public Transform TargetPlayer;

    //Help smooth out inputs
    public float smoothing = 0.125f;
    public float turnSpeed = 4f;

    //How far the camera is from the player
    private float DefaultYZoom = 7f;
    private float DefaultZZoom = 10f;

    private Vector3 VOffset;
    void Start()
    {
        //Set   VOffset
        VOffset = new Vector3(TargetPlayer.position.x, TargetPlayer.position.y + DefaultYZoom, TargetPlayer.position.z + DefaultZZoom);
    }
    void LateUpdate()
    {
        //Check if right click is held to rotate the camera
        if (Input.GetButton("CameraLock"))
        {
            VOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * VOffset;
            VOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.left) * VOffset;

        }
        //update to follow the player
        transform.position = TargetPlayer.position + VOffset;
        transform.LookAt(TargetPlayer.position);
    }
}


