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

    public virtual bool TakeDamage(int damage)
    {
        int MHp;
        MHp = (damage - Def);

        if (MHp <= 0)
        {
            MHp = 1;
        }
        hp -= MHp;
        if (hp <= 0)
        {
            Faint = true;
            return true;
        }
        else
            return false;
    }
}

