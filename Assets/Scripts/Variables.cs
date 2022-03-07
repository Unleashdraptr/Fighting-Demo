using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public static int EnemiesToKill;
    public static bool random;
    public static Vector3 PlayerPos;
    public static int SeedNumber;
    public static bool Pause;
    public static bool FirstLoad;
    public static bool FirstBattle;
    public Transform Playerposition;
    private void Start()
    {
        Playerposition.position = PlayerPos;
        if(random == true)
        {
            SeedNumber = Random.Range(-10000, 10000);
        }
    }
}
