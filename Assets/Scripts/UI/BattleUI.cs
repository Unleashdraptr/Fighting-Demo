using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    //Objects that are used
    public Text[] Name;
    public Text[] Lvl;
    public Slider[] Hpslider;
    public Slider[] StaminaSlider;

    public void SetupP1UI(Player1 player1)
    {        
        //Sets the UI with the information about Player 1
        Name[0].text = player1.Name;
        Lvl[0].text = "Lvl " + player1.Lvl;
        Hpslider[0].maxValue = player1.Maxhp;
        Hpslider[0].value = player1.hp;
        StaminaSlider[0].maxValue = player1.Strength;
        StaminaSlider[0].value = player1.Strength;
    }
    public void SetP1Health(int hp)
    {
        //Set the health
        Hpslider[0].value = hp;
    }
    public void SetP1Stamina(int Strength)
    {
        //Set the stamina
        StaminaSlider[0].value = Strength;
    }


    public void SetupP2UI(Player2 player2)
    {
        //Sets the UI with the information about Player 2
        Name[1].text = player2.Name;
        Lvl[1].text = "Lvl " + player2.Lvl;
        Hpslider[1].maxValue = player2.Maxhp;
        Hpslider[1].value = player2.hp;
        StaminaSlider[1].maxValue = player2.Ammo;
        StaminaSlider[1].value = player2.Ammo;
    }
    public void SetP2Health(int hp)
    {
        //Set the health
        Hpslider[1].value = hp;
    }
    public void SetP2Stamina(int Ammo)
    {
        //Set the stamina
        StaminaSlider[1].value = Ammo;
    }


    public void SetupP3UI(Player3 player3)
    {
        //Sets the UI with the information about Player 3
        Name[2].text = player3.Name;
        Lvl[2].text = "Lvl " + player3.Lvl;
        Hpslider[2].maxValue = player3.Maxhp;
        Hpslider[2].value = player3.hp;
        StaminaSlider[2].maxValue = player3.Mana;
        StaminaSlider[2].value = player3.Mana;
    }
    public void SetP3Health(int hp)
    {
        //Set the health
        Hpslider[2].value = hp;
    }
    public void SetP3Stamina(int Mana)
    {
        //Set the stamina
        StaminaSlider[2].value = Mana;
    }


    public void SetupEnemyUI(Enemystats enemy)
    {
        //Sets the UI with the information about the Enemy
        Name[3].text = enemy.Name;
        Lvl[3].text = "Lvl " + enemy.Lvl;
        Hpslider[3].maxValue = enemy.MaxHp;
        Hpslider[3].value = enemy.Hp;
    }
    public void SetEnemyHealth(int hp)
    {
        //Set the health
        Hpslider[3].value = hp;
    }
    public void SetEnemyStamina(int Strength)
    {
        //Set the stamina
        StaminaSlider[3].value = Strength;
    }
}
