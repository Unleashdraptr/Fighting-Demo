using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState {START, WIN, LOSE, PLAYER1TURN, PLAYER2TURN, PLAYER3TURN, ENEMYTURN }
public class BattleStuff : MonoBehaviour
{
    Enemystats EnemyStats;
    Player1 Player1stats;
    Player2 Player2stats;
    Player3 Player3stats;
    public GameObject[] Prefabs;

    public Text Battletext;

    public Transform[] Locations;

    public UI HUD;


    public BattleState state;


    public void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupUI());
        HideAttackOptions();
        HideOtherButtons();
    }
    IEnumerator SetupUI()
    {
        GameObject player1 = Instantiate(Prefabs[0], Locations[0]);
        Player1stats = player1.GetComponent<Player1>();

        GameObject player2 = Instantiate(Prefabs[1], Locations[1]);
        Player2stats = player2.GetComponent<Player2>();

        GameObject player3 = Instantiate(Prefabs[2], Locations[2]);
        Player3stats = player3.GetComponent<Player3>();

        GameObject enemy = Instantiate(Prefabs[3], Locations[3]);
        EnemyStats = enemy.GetComponent<Enemystats>();

        SetPlayer1Stats(Player1stats);
        SetPlayer2Stats(Player2stats);
        SetPlayer3Stats(Player3stats);
        SetEnemyStats(EnemyStats);

        HUD.SetupP1UI(Player1stats);
        HUD.SetupP2UI(Player2stats);
        HUD.SetupP3UI(Player3stats);
        HUD.SetupEnemyUI(EnemyStats);

        Battletext.text = "Wild Enemies Appear!";

        yield return new WaitForSeconds(4f);

        state = BattleState.PLAYER1TURN;
        Player1Turn();


    }
    public void Player1Turn()
    {
        Battletext.text = "Player 1 choose your move!";
        ShowOtherButtons();
    }
    public void Player2Turn()
    {
        state = BattleState.PLAYER2TURN;
        Battletext.text = "Player 2 choose your move!";
        ShowOtherButtons();
    }
    public void Player3Turn()
    {
        state = BattleState.PLAYER3TURN;
        Battletext.text = "Player 3 choose your move!";
        ShowOtherButtons();
    }
    public void EnemyTurn()
    {
        state = BattleState.ENEMYTURN;
        Battletext.text = "Enemy turn!";
        EnemyAIMove();
    }
    public void OnAttackButton()
    {
        HideAttackOptions();
        if (state == BattleState.PLAYER1TURN | state == BattleState.PLAYER2TURN | state == BattleState.PLAYER3TURN)
        {
            StartCoroutine(PlayerAttack());
        }
        else
            return;
    }
    IEnumerator PlayerAttack()
    {
        bool faint = false;
        if (state == BattleState.PLAYER1TURN)
        {
            faint = EnemyStats.TakeDamage(Player1stats.Atk);
            Player1stats.Strength -= 1;
        }
        if (state == BattleState.PLAYER2TURN)
        {
            faint = EnemyStats.TakeDamage(Player2stats.Atk);
            Player2stats.Ammo -= 1;
        }
        if (state == BattleState.PLAYER3TURN)
        {
            faint = EnemyStats.TakeDamage(Player3stats.Atk);
            Player3stats.Mana -= 1;
        }
        HUD.SetEnemyHealth(EnemyStats.Hp);
        HUD.SetP1Stamina(Player1stats.Strength);
        HUD.SetP2Stamina(Player2stats.Ammo);
        HUD.SetP3Stamina(Player3stats.Mana);
        if (faint == true)
        {
            Destroy(GameObject.Find("BattleEnemy(Clone)"));
            Battletext.text = "Player Wins!";
            yield return new WaitForSeconds(4f);
            BattleWin();
        }
        if (faint == false)
        {
            if (state == BattleState.PLAYER3TURN)
            {
                EnemyTurn();
            }
            if (state == BattleState.PLAYER2TURN && Player3stats.Faint == false)
            {
                Player3Turn();
            }
            if (state == BattleState.PLAYER1TURN && Player2stats.Faint == false)
            {
                Player2Turn();
            }
            else
            {
                EnemyTurn();
            }
        }
    }
    public void EnemyAIMove()
    {
        bool faint = false;
        int Target = Random.Range(0, 4);
        if (Target == 1)
        {
            Battletext.text = "Enemies attacks Player 1";
            faint = Player1stats.TakeDamage(EnemyStats.Atk);
            if(faint == true)
            {
                Destroy(GameObject.Find("BattlePlayer1(Clone)"));
            }
        }
        if (Target == 2)
        {
            Battletext.text = "Enemies attacks Player 2";
            faint = Player2stats.TakeDamage(EnemyStats.Atk);
            if (faint == true)
            {
                Destroy(GameObject.Find("BattlePlayer2(Clone)"));
            }
        }
        if (Target == 3)
        {
            Battletext.text = "Enemies attacks Player 3";
            faint = Player3stats.TakeDamage(EnemyStats.Atk);
            if (faint == true)
            {
                Destroy(GameObject.Find("BattlePlayer3(Clone)"));
            }
        }
        HUD.SetEnemyStamina(EnemyStats.Strength);
        HUD.SetP1Health(Player1stats.hp);
        HUD.SetP2Health(Player2stats.hp);
        HUD.SetP3Health(Player3stats.hp);
        if (faint == false)
        {
            if (Player1stats.Faint == false)
            {
                state = BattleState.PLAYER1TURN;
                Player1Turn();
            }
            if (Player2stats.Faint == false)
            {
                state = BattleState.PLAYER2TURN;
                Player2Turn();
            }
            if (Player3stats.Faint == false)
            {
                state = BattleState.PLAYER3TURN;
                Player3Turn();
            }
        }
    }
    public void Randomised(ref int HpAmount, ref int AtkAmount, ref int DefAmount, ref int SpdAmount, ref int AccAmount, ref int LvlAmount)
    {
        HpAmount = Random.Range(1, 10);
        AtkAmount = Random.Range(1, 10);
        DefAmount = Random.Range(1, 10);
        SpdAmount = Random.Range(1, 10);
        AccAmount = Random.Range(1, 10);
        LvlAmount = Random.Range(1, 5);
    }
    public void SetPlayer1Stats(Player1 Player1)
    {
        int HpAmount = 0;
        int AtkAmount = 0;
        int DefAmount = 0;
        int SpdAmount = 0;
        int AccAmount = 0;
        int LvlAmount = 0;
        Randomised(ref HpAmount, ref AtkAmount, ref DefAmount, ref SpdAmount, ref AccAmount, ref LvlAmount);

        Player1.Lvl = LvlAmount;
        Player1.hp = (HpAmount * Player1.Lvl);
        Player1.Maxhp = Player1.hp;
        Player1.Atk = (AtkAmount * Player1.Lvl);
        Player1.Def = (DefAmount * Player1.Lvl);
        Player1.Spd = (SpdAmount * Player1.Lvl);
        Player1.Acc = (AccAmount * Player1.Lvl);
    }
    public void SetPlayer2Stats(Player2 Player2)
    {
        int HpAmount = 0;
        int AtkAmount = 0;
        int DefAmount = 0;
        int SpdAmount = 0;
        int AccAmount = 0;
        int LvlAmount = 0;
        Randomised(ref HpAmount, ref AtkAmount, ref DefAmount, ref SpdAmount, ref AccAmount, ref LvlAmount);

        Player2.Lvl = LvlAmount;
        Player2.hp = (HpAmount * Player2.Lvl);
        Player2.Maxhp = Player2.hp;
        Player2.Atk = (AtkAmount * Player2.Lvl);
        Player2.Def = (DefAmount * Player2.Lvl);
        Player2.Spd = (SpdAmount * Player2.Lvl);
        Player2.Acc = (AccAmount * Player2.Lvl);
    }
    public void SetPlayer3Stats(Player3 Player3)
    {
        int HpAmount = 0;
        int AtkAmount = 0;
        int DefAmount = 0;
        int SpdAmount = 0;
        int AccAmount = 0;
        int LvlAmount = 0;
        Randomised(ref HpAmount, ref AtkAmount, ref DefAmount, ref SpdAmount, ref AccAmount, ref LvlAmount);

        Player3.Lvl = LvlAmount;
        Player3.hp = (HpAmount * Player3.Lvl);
        Player3.Maxhp = Player3.hp;
        Player3.Atk = (AtkAmount * Player3.Lvl);
        Player3.Def = (DefAmount * Player3.Lvl);
        Player3.Spd = (SpdAmount * Player3.Lvl);
        Player3.Acc = (AccAmount * Player3.Lvl);
    }
    public void SetEnemyStats(Enemystats enemy)
    {
        int HpAmount = 0;
        int AtkAmount = 0;
        int DefAmount = 0;
        int SpdAmount = 0;
        int AccAmount = 0;
        int LvlAmount = 0;
        Randomised(ref HpAmount, ref AtkAmount, ref DefAmount, ref SpdAmount, ref AccAmount, ref LvlAmount);

        enemy.Lvl = LvlAmount;
        enemy.Hp = (HpAmount * enemy.Lvl);
        enemy.MaxHp = enemy.Hp;
        enemy.Atk = (AtkAmount * enemy.Lvl);
        enemy.Def = (DefAmount * enemy.Lvl);
        enemy.Spd = (SpdAmount * enemy.Lvl);
        enemy.Acc = (AccAmount * enemy.Lvl);
    }
    public void HideAttackOptions()
    {
        // Hide button
        GameObject.Find("Attack 1").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Attack 2").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Attack 3").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Attack 4").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Quit").transform.localScale = new Vector3(0, 0, 0);
    }
    public void ShowAttackOptions()
    {
        // Show button
        GameObject.Find("Attack 1").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject.Find("Attack 2").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject.Find("Attack 3").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject.Find("Attack 4").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject.Find("Quit").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    public void ShowOtherButtons()
    {
        GameObject.Find("Battle").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject.Find("RunAway").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    public void HideOtherButtons()
    {
        GameObject.Find("Battle").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("RunAway").transform.localScale = new Vector3(0, 0, 0);
    }
    public void Fight()
    {
        ShowAttackOptions();
        HideOtherButtons();
    }
    public void Quit()
    {
        HideAttackOptions();
        ShowOtherButtons();
    }
    public void BattleWin()
    {
        StartCoroutine(Win());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void BattleEnd()
    {
        StartCoroutine(RunAway());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    IEnumerator RunAway()
    {
        Battletext.text = "You run away!";
        yield return new WaitForSeconds(4f);
    }
    IEnumerator Win()
    {
        Battletext.text = "Your Party Wins!";
        yield return new WaitForSeconds(4f);
    }
}

