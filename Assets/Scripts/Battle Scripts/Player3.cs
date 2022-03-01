using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : Universal_Stats
{
    public int Mana_Cost = 0;
    public int Mana = 20;
    public int MAXMana = 20;
    public string Name = "Mage";

    public bool TakeDamage(int damage)
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






    //Moves
    public void Move1(ref int Pow, ref int Cost)
    {
        //Single stab using 1 strength and only using players Atk
        Pow = Atk;
        Cost = Mana_Cost;
    }
    public void Move2(ref int Pow, ref int Cost)
    {
        Pow = Atk;
        Cost = Mana_Cost;
    }
    public void Move3(ref int Pow, ref int Cost)
    {
        Pow = Atk;
        Cost = Mana_Cost;
    }
    public void Move4(ref int Pow, ref int Cost)
    {
        Pow = Atk;
        Cost = Mana_Cost;
    }
}
