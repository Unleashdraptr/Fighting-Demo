using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMovement : MonoBehaviour
{
    public Transform Player;
    public Transform Range;
    public GameObject Enemy;
    public GameObject ShinyEnemy;
    Vector3 Location = Vector3.zero;
    // Update is called once per frame
    private void Start()
    {
        Player.position = Variables.PlayerPos;
    }
    void Update()
    {
        if (Variables.Pause == false)
        {
            int Spawn = Random.Range(1, 750);
            int Shiny = Random.Range(1, 400000);
            if (Spawn == 500)
            {
                if (Shiny == 2)
                {
                    Debug.Log("Shiny");
                    EnemyLocation(ref Location);
                    Instantiate(ShinyEnemy, Location, Quaternion.identity, GameObject.FindGameObjectWithTag("Enemy Numbers").transform);
                }
                else
                    EnemyLocation(ref Location);
                    Instantiate(Enemy, Location, Quaternion.identity, GameObject.FindGameObjectWithTag("Enemy Numbers").transform);
            }
            Range.position = new Vector3(Player.position.x, 150, Player.position.z);
        }
    }
    void EnemyLocation(ref Vector3 Location)
    {
        int X = Random.Range(-300, 300);
        int Y = Random.Range(0, 200);
        int Z = Random.Range(-300, 300);
        Location = new Vector3(Player.position.x+X, Player.position.y + Y, Player.position.z+Z);
    }
}
