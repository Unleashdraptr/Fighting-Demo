using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle_Trigger : MonoBehaviour
{
    public Transform PlayerPos;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Variables.PlayerPos = new Vector3(PlayerPos.position.x, PlayerPos.position.y, PlayerPos.position.z);
            Debug.Log("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
