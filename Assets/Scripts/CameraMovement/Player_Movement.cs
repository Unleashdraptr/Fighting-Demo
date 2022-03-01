using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //Variables

    public float jump = 10f;
    public float Dash = 2.0f;
    public float gravity = 9.8f;
    public Vector3 Direction = Vector3.zero;
    public Vector3 Rotation = Vector3.zero;
    public Vector3 StartPos = Vector3.zero;
    public float MoveSpeed = 10;
    public float RotateSpeed = 50;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            Direction = new Vector3(0, 0, Input.GetAxis("Vertical")*MoveSpeed);
            Rotation = new Vector3(0, Input.GetAxis("Horizontal")*RotateSpeed, 0);
            Direction = transform.TransformDirection(Direction);
            //Jumping
            if (Input.GetButton("Jump"))
            {
                Direction.y = jump;
            }
            if (Input.GetButton("Dash"))
            {
                Direction.z *= Dash;
            }
        }
        //Applying gravity to the controller
        Direction.y -= gravity * Time.deltaTime;
        //Making the character move
        transform.Rotate(Rotation * Time.deltaTime);
        controller.Move(Direction * Time.deltaTime);
        
    }
}
