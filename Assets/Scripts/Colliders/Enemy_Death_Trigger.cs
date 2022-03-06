using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death_Trigger : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
