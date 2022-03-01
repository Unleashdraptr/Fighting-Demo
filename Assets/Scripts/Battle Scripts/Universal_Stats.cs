using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Universal_Stats : MonoBehaviour
{
    public int Maxhp = 100;
    public int hp = 50;
    public int Atk = 0;
    public int Def = 0;
    public int Spd = 0;
    public int Acc = 0;

    public int Lvl = 0;
    public bool Faint = false;
}
public class Enemy
{
    public string Name = " ";
    public int MAXHP;
    public int Hp;
    public int Atk;
    public int Def;
    public int Spd;
    public int Lvl;
    public int Mana = 0;
    public int Ammo = 0;
    public int Strength = 0;

    //Types
    public bool Magic = false;
    public bool Melee = false;
    public bool Range = false;

    //States
    public bool faint = false;
}

