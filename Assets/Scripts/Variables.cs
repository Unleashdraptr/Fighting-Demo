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
    BattleStuff battle;
    private void Start()
    {
        if (FirstLoad == true)
        {
            battle.SetPlayerStats();
            FirstLoad = false;
        }
    }
}
