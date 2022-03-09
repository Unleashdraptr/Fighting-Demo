using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float jump = 8f;
    float gravity = 9.8f;
    Vector3 Direction = Vector3.zero;
    Vector3 Rotation = Vector3.zero;

    void Update()
    {
        //checks if the game is paused
        if (Variables.Pause == false)
        {
            int Change;
            CharacterController controller = GetComponent<CharacterController>();
            // is the controller on the ground?
            if (controller.isGrounded)
            {
                //Feed moveDirection with a random input.
                Direction = transform.TransformDirection(Direction);
                Change = Random.Range(1, 500);
                //randomly make the character do one of these things
                if (Change == 3)
                {
                    Direction.y = jump;
                }
                if (Change == 5)
                {
                    WalkingDirection();
                }
                if (Change == 450)
                {
                    Direction = new Vector3(0, 0, 0);
                    Rotation = new Vector3(0, 0, 0);
                }
            }
            //Applying gravity to the controller
            Direction.y -= gravity * Time.deltaTime;
            //Making the character move and rotate
            transform.Rotate(Rotation * Time.deltaTime);
            controller.Move(Direction * Time.deltaTime);
        }
        //Destorys the player incase it falls out the world
        if(transform.position.y <= -500)
        {
            Destroy(gameObject);
        }
    }
    //Picks a random direction and speed
    void WalkingDirection()
    {
        Direction = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        Rotation = new Vector3(0, Random.Range(-50, 50), 0);
    }
}
