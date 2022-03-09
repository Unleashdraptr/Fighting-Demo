using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Camera : MonoBehaviour
{
    public Transform BattlePlane;
    private Vector3 Camoffset;
    public float CamSpeed;
    void Start()
    {
        //Set the camera position of where it'll rotate and how large its circle of rotation will be
        Camoffset = new Vector3(BattlePlane.position.x, BattlePlane.position.y + 10.0f, BattlePlane.position.z + 25.0f);
    }
    void LateUpdate()
    {
        //Turning speed and changing the cameras angle
        Camoffset = Quaternion.AngleAxis(CamSpeed, Vector3.up) * Camoffset;
        transform.position = BattlePlane.position + Camoffset;
        transform.LookAt(BattlePlane.position);
    }
}

