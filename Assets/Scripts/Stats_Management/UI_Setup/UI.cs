using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text[] Name;
    public Text[] Lvl;
    public Slider[] Hpslider;
    public Slider[] StaminaSlider;

    public void SetupP1UI(Player1 player1)
    {
        Name[0].text = player1.Name;
        Lvl[0].text = "Lvl " + player1.Lvl;
        Hpslider[0].maxValue = player1.Maxhp;
        Hpslider[0].value = player1.hp;
        StaminaSlider[0].maxValue = player1.MAXStrength;
        StaminaSlider[0].value = player1.Strength;
    }
    public void SetP1Health(int hp)
    {
        Hpslider[0].value = hp;
    }
    public void SetP1Stamina(int hp)
    {
        StaminaSlider[0].value = hp;
    }


    public void SetupP2UI(Player2 player2)
    {
        Name[1].text = player2.Name;
        Lvl[1].text = "Lvl " + player2.Lvl;
        Hpslider[1].maxValue = player2.Maxhp;
        Hpslider[1].value = player2.hp;
        StaminaSlider[1].maxValue = player2.MAXAmmo;
        StaminaSlider[1].value = player2.Ammo;
    }
    public void SetP2Health(int hp)
    {
        Hpslider[1].value = hp;
    }
    public void SetP2Stamina(int hp)
    {
        StaminaSlider[1].value = hp;
    }


    public void SetupP3UI(Player3 player3)
    {
        Name[2].text = player3.Name;
        Lvl[2].text = "Lvl " + player3.Lvl;
        Hpslider[2].maxValue = player3.Maxhp;
        Hpslider[2].value = player3.hp;
        StaminaSlider[2].maxValue = player3.MAXMana;
        StaminaSlider[2].value = player3.Mana;
    }
    public void SetP3Health(int hp)
    {
        Hpslider[2].value = hp;
    }
    public void SetP3Stamina(int hp)
    {
        StaminaSlider[2].value = hp;
    }


    public void SetupEnemyUI(Enemystats enemy)
    {
        Name[3].text = enemy.Name;
        Lvl[3].text = "Lvl " + enemy.Lvl;
        Hpslider[3].maxValue = enemy.MaxHp;
        Hpslider[3].value = enemy.Hp;
    }
    public void SetEnemyHealth(int hp)
    {
        Hpslider[3].value = hp;
    }
    public void SetEnemyStamina(int Strength)
    {
        StaminaSlider[3].value = Strength;
    }
}
