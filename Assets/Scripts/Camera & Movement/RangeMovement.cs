using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMovement : MonoBehaviour
{
    //Objects needed
    public Transform Player;
    public Transform Range;
    public GameObject Enemy;
    public GameObject ShinyEnemy;
    Vector3 Location = Vector3.zero;
    void Update()
    {
        //If unpaused
        if (Variables.Pause == false)
        {
            //2 Random values every frame
            int Spawn = Random.Range(1, 950);
            int Shiny = Random.Range(1, 40000);
            //Spawns if 500
            if (Spawn == 500)
            {
                //Spawns the shiny if Shiny is 2 on that frame
                if (Shiny == 2)
                {
                    //Spawns the enemy around the player and stores it under Enemy Numbers
                    EnemyLocation(ref Location);
                    Instantiate(ShinyEnemy, Location, Quaternion.identity, GameObject.FindGameObjectWithTag("Enemy Numbers").transform);
                }
                else
                    //Spawns the enemy around the player and stores it under Enemy Numbers
                    EnemyLocation(ref Location);
                    Instantiate(Enemy, Location, Quaternion.identity, GameObject.FindGameObjectWithTag("Enemy Numbers").transform);
            }
            //Keeps the box at a set Y but have it follow the player around the map
            Range.position = new Vector3(Player.position.x, 150, Player.position.z);
        }
    }
    void EnemyLocation(ref Vector3 Location)
    {
        //Randomly picks a location to spawn around the player
        int X = Random.Range(-300, 300);
        int Y = Random.Range(10, 200);
        int Z = Random.Range(-300, 300);
        Location = new Vector3(Player.position.x+X, Player.position.y + Y, Player.position.z+Z);
    }
}
