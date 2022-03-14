using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle_Trigger : MonoBehaviour
{
    public Transform PlayerPos;
    private void OnCollisionEnter(Collision collision)
    {
        //Checks if the player collided with an enemy and if so enter the battle scene while storing the players position
        if (collision.gameObject.tag == "Enemy")
        {
            Variables.PlayerPos = PlayerPos.position;
            SceneManager.LoadScene("Battle");
        }
    }

}
