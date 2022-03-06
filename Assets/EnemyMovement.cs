using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float jump = 8f;
    float gravity = 9.8f;
    Vector3 Direction = Vector3.zero;
    Vector3 WalkDirection = Vector3.zero;
    Vector3 SetRotation = Vector3.zero;
    Vector3 Rotation = Vector3.zero;
    void Start()
    {
        WalkingDirection();
    }

    void Update()
    {
        if (Variables.Pause == false)
        {
            int Change;
            CharacterController controller = GetComponent<CharacterController>();
            // is the controller on the ground?
            if (controller.isGrounded)
            {
                //Feed moveDirection with input.
                Direction = WalkDirection;
                Rotation = SetRotation;
                Direction = transform.TransformDirection(Direction);
                Change = Random.Range(1, 500);
                if (Change == 3)
                {
                    Direction.y = jump;
                }
                if (Change == 5)
                {
                    WalkingDirection();
                }
            }
            //Applying gravity to the controller
            Direction.y -= gravity * Time.deltaTime;
            //Making the character move
            transform.Rotate(Rotation * Time.deltaTime);
            controller.Move(Direction * Time.deltaTime);
        }
        if(transform.position.y <= -500)
        {
            Destroy(gameObject);
        }
    }
    void WalkingDirection()
    {
        WalkDirection = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        SetRotation = new Vector3(0, Random.Range(-50, 50), 0);
    }
}
