using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMovement : MonoBehaviour
{
    public Transform Player;
    public Transform Range;
    public GameObject Enemy;
    Vector3 Location = Vector3.zero;
    // Update is called once per frame
    private void Start()
    {
        Player.position = Variables.PlayerPos;
    }
    void Update()
    {
        int Spawn = Random.Range(1, 1000);
        if (Spawn == 500)
        {
            EnemyLocation(ref Location);
            Instantiate(Enemy, Location, Quaternion.identity, GameObject.FindGameObjectWithTag("Enemy Numbers").transform);
        }
        Range.position = new Vector3 (Player.position.x, 150, Player.position.z);
    }
    void EnemyLocation(ref Vector3 Location)
    {
        int X = Random.Range(-100, 100);
        int Z = Random.Range(-100, 100);
        Location = new Vector3(Player.position.x+X, Player.position.y + 70, Player.position.z+Z);
    }
}
