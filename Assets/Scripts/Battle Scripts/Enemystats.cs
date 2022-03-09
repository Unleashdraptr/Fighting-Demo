using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemystats : MonoBehaviour
{
    //Stats the enemy will use along with a Damage function
    public string Name;
    public int Lvl;
    public int Hp;
    public int MaxHp;
    public int Atk;
    public int Def;

    public bool faint = false;
    public bool TakeDamage(int damage)
    {
        int MHp;
        MHp = (damage-Def);

        if (MHp <= 0)
        {
            MHp = 1;
        }
        Hp -= MHp;
        if (Hp <= 0)
        {
            faint = true;
            return true;
        }
        else
            return false;
    }
}
