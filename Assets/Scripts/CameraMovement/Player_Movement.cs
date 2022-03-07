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
        // is the controller on the ground and the game not pasued?
        if (Variables.Pause == false)
        {
            if (controller.isGrounded)
            {
                //Feed direction and rotation into Vector3s.
                Direction = new Vector3(0, 0, Input.GetAxis("Vertical") * MoveSpeed);
                Rotation = new Vector3(0, Input.GetAxis("Horizontal") * RotateSpeed, 0);
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
        if (transform.position.y <= -25)
        {
            gameObject.transform.localScale = new Vector3(0,0,0);
            Death();
        }
    }
    public void Death()
    {
        GameObject.Find("DeathEffect").transform.localScale = new Vector3(10.8f, 5f, 0);
        GameObject.Find("Exit").transform.localScale = new Vector3(2, 2, 2);
        Variables.Pause = true;
    }
}
