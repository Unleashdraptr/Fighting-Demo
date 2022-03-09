using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, PLAYER3TURN, ENEMYTURN }
public class BattleStuff : MonoBehaviour
{
    //Variables for all the stats and objects needed
    Enemystats EnemyStats;
    Player1 Player1stats;
    Player2 Player2stats;
    Player3 Player3stats;
    public GameObject[] Prefabs;
    public Text Battletext;
    public Transform[] Locations;

    public BattleUI HUD;
    public BattleState state;

    public bool P1Block;
    public bool P2Block;
    public bool P3Block;
    public void Start()
    {
        //Setup and then start the battle (Randomising stats)
        state = BattleState.START;
        StartCoroutine(SetupUI());
        HideAttackOptions();
        HideOtherButtons();
    }
    IEnumerator SetupUI()
    {
        //Assign the stats to the objects
        GameObject player1 = Instantiate(Prefabs[0], Locations[0]);
        Player1stats = player1.GetComponent<Player1>();

        GameObject player2 = Instantiate(Prefabs[1], Locations[1]);
        Player2stats = player2.GetComponent<Player2>();

        GameObject player3 = Instantiate(Prefabs[2], Locations[2]);
        Player3stats = player3.GetComponent<Player3>();

        GameObject enemy = Instantiate(Prefabs[3], Locations[3]);
        EnemyStats = enemy.GetComponent<Enemystats>();

        //Set stats
        SetPlayerStats();
        SetEnemyStats(EnemyStats);

        //Update UI
        HUD.SetupP1UI(Player1stats);
        HUD.SetupP2UI(Player2stats);
        HUD.SetupP3UI(Player3stats);
        HUD.SetupEnemyUI(EnemyStats);

        Battletext.text = "Wild Enemies Appear!";

        yield return new WaitForSeconds(3f);

        Player1Turn();
    }

    //Set Game state and tell player whos turn it is
    public void Player1Turn()
    {
        state = BattleState.PLAYER1TURN;
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
        Battletext.text = "Enemy's turn to attack!";
        StartCoroutine(EnemyAIAttack());
    }

    //Takes the players button choice and uses it to attack or perform an action depending on which game state it is in.
    IEnumerator PlayerAttack(int Num)
    {
        bool faint = false;
        if (state == BattleState.PLAYER1TURN)
        {
            if (Player1stats.Strength <= 0)
            {
                Battletext.text = "Player 1 can't move! They need to recharge";
                yield return new WaitForSeconds(2f);
                Player1stats.Strength += 2;
            }
            else
            {
                if (Num == 1)
                {
                    Battletext.text = "Player 1 Attacks the Enemy!";
                    yield return new WaitForSeconds(2f);
                    faint = EnemyStats.TakeDamage(Player1stats.Atk);
                    Player1stats.Strength -= 1;
                }
                if (Num == 2)
                {
                    if (P1Block == true)
                    {
                        Battletext.text = "Player 1 is already blocking!";
                        yield return new WaitForSeconds(2f);
                        Battletext.text = "Player 1 Attacks the enemy instead!";
                        yield return new WaitForSeconds(2f);
                        faint = EnemyStats.TakeDamage(Player1stats.Atk);
                        Player1stats.Strength -= 1;
                    }
                    if (P1Block == false)
                    {
                        Battletext.text = "Player 1 prepares for the Enemy's next attack!";
                        P1Block = true;
                        Player1stats.Def *= 10;
                        yield return new WaitForSeconds(2f);
                        Player1stats.Strength += 5;
                    }
                }
                if (Num == 3)
                {
                    Battletext.text = "Player 1 attacks the Enemy in an all out attack!";
                    Player1stats.Atk += Player1stats.Strength;
                    faint = EnemyStats.TakeDamage(Player1stats.Atk);
                    Player1stats.Atk -= Player1stats.Strength;
                    yield return new WaitForSeconds(2f);
                    Player1stats.Strength -= 20;
                }
                if (Num == 4)
                {
                    Battletext.text = "Player 2 blocks for the rest of the team";
                    P1Block = true;
                    Player1stats.Def *= 10;
                    P2Block = true;
                    Player2stats.Def *= 10;
                    P3Block = true;
                    Player3stats.Def *= 10;
                    yield return new WaitForSeconds(2f);
                    Player1stats.Strength -= 20;
                }
                if (Player1stats.Strength < 0)
                {
                    Player1stats.Strength = 0;
                }
            }
        }
        if (state == BattleState.PLAYER2TURN)
        {
            if (Player2stats.Ammo <= 0)
            {
                Battletext.text = "Player 1 attacks the Enemy in an all out attack!";
                yield return new WaitForSeconds(2f);
                Player2stats.Ammo += 2;
            }
            else
            {
                if (Num == 1)
                {
                    Battletext.text = "Player 2 Attacks the Enemy!";
                    yield return new WaitForSeconds(2f);
                    faint = EnemyStats.TakeDamage(Player2stats.Atk);
                    Player2stats.Ammo -= 1;
                }
                if (Num == 2)
                {
                    if (P2Block == true)
                    {
                        Battletext.text = "Player 2 is already blocking!";
                        yield return new WaitForSeconds(2f);
                        Battletext.text = "Player 2 Attacks the Enemy instead!";
                        yield return new WaitForSeconds(2f);
                        faint = EnemyStats.TakeDamage(Player2stats.Atk);
                        Player2stats.Ammo -= 1;
                    }
                    if (P2Block == false)
                    {
                        Battletext.text = "Player 1 attacks the Enemy in an all out attack!";
                        P2Block = true;
                        Player2stats.Def *= 10;
                        yield return new WaitForSeconds(2f);
                        Player2stats.Ammo += 5;
                    }
                }
                if (Num == 3)
                {
                    Battletext.text = "Player 2 attacks the Enemy in an all out attack!";
                    Player2stats.Atk += Player2stats.Ammo;
                    faint = EnemyStats.TakeDamage(Player2stats.Atk);
                    Player2stats.Atk -= Player2stats.Ammo;
                    yield return new WaitForSeconds(2f);
                    Player2stats.Ammo -= 20;
                }
                if (Num == 4)
                {
                    Battletext.text = "Player 2 restores the rest of the teams stamina using their own lifeforce!";
                    Player1stats.Strength += 5 + Player2stats.Ammo;
                    Player3stats.Mana += 5 + Player2stats.Ammo;
                    Player2stats.Ammo += 5 + Player2stats.Ammo;
                    if (Player1stats.Strength > 20)
                    {
                        Player1stats.Strength = 20;
                    }
                    if (Player2stats.Ammo > 20)
                    {
                        Player2stats.Ammo = 20;
                    }
                    if (Player3stats.Mana > 20)
                    {
                        Player3stats.Mana = 20;
                    }
                    yield return new WaitForSeconds(2f);
                }
                if (Player2stats.Ammo < 0)
                {
                    Player2stats.Ammo = 0;
                }
            }
        }
        if (state == BattleState.PLAYER3TURN)
        {
            if (Player3stats.Mana <= 0)
            {
                Battletext.text = "Player 3 is out of Mana and needs to rest to recharge!";
                yield return new WaitForSeconds(2f);
                Player3stats.Mana += 2;
            }
            else
            {
                if (Num == 1)
                {
                    Battletext.text = "Player 3 Attacks the Enemy!";
                    yield return new WaitForSeconds(2f);
                    faint = EnemyStats.TakeDamage(Player3stats.Atk);
                    Player3stats.Mana -= 1;
                }
                if (Num == 2)
                {
                    if (P3Block == true)
                    {
                        Battletext.text = "Player 3 is already blocking!";
                        yield return new WaitForSeconds(2f);
                        Battletext.text = "Player 3 Attacks the Enemy instead!";
                        yield return new WaitForSeconds(2f);
                        faint = EnemyStats.TakeDamage(Player3stats.Atk);
                        Player3stats.Mana -= 1;
                    }
                    if (P3Block == false)
                    {
                        Battletext.text = "Player 3 prepares for the Enemy's next attack!";
                        P3Block = true;
                        Player3stats.Def *= 10;
                        yield return new WaitForSeconds(2f);
                        Player3stats.Mana += 5;
                    }
                }
                if (Num == 3)
                {
                    Battletext.text = "Player 3 attacks the Enemy in an all out attack!";
                    Player3stats.Atk += Player3stats.Mana;
                    faint = EnemyStats.TakeDamage(Player3stats.Atk);
                    Player3stats.Atk -= Player3stats.Mana;
                    yield return new WaitForSeconds(2f);
                    Player3stats.Mana -= 20;
                }
                if (Num == 4)
                {
                    Battletext.text = "Player 3 Heals the rest of the team";
                    Player1stats.hp += Player3stats.Mana;
                    Player2stats.hp += Player3stats.Mana;
                    Player3stats.hp += Player3stats.Mana;
                    if (Player1stats.hp > Player1stats.Maxhp)
                    {
                        Player1stats.hp = Player1stats.Maxhp;
                    }
                    if (Player2stats.hp > Player2stats.Maxhp)
                    {
                        Player2stats.hp = Player2stats.Maxhp;
                    }
                    if (Player3stats.hp > Player3stats.Maxhp)
                    {
                        Player3stats.hp = Player3stats.Maxhp;
                    }
                    yield return new WaitForSeconds(2f);
                    Player3stats.Mana -= 20;
                }
                if (Player3stats.Mana < 0)
                {
                    Player3stats.Mana = 0;
                }
            }
        }
        HUD.SetEnemyHealth(EnemyStats.Hp);
        HUD.SetP1Stamina(Player1stats.Strength);
        HUD.SetP2Stamina(Player2stats.Ammo);
        HUD.SetP3Stamina(Player3stats.Mana);
        if (faint == true)
        {
            Destroy(GameObject.Find("BattleEnemy(Clone)"));
            yield return new WaitForSeconds(4f);
            StartCoroutine(BattleWin());
        }
        if (faint == false)
        {
            if (state == BattleState.PLAYER3TURN)
            {
                EnemyTurn();
            }
            else if (state == BattleState.PLAYER2TURN && Player3stats.Faint == false)
            {
                Player3Turn();
            }
            else if (state == BattleState.PLAYER1TURN && Player2stats.Faint == true)
            {
                Player3Turn();
            }
            else if (state == BattleState.PLAYER1TURN && Player2stats.Faint == false)
            {
                Player2Turn();
            }
            else
            {
                EnemyTurn();
            }
        }
    }

    //When the game state is Enemy it will then call this to attack randomly before cycling around again
    IEnumerator EnemyAIAttack()
    {
        bool faint = false;
        int Target = Random.Range(1, 4);
        yield return new WaitForSeconds(2f);
        if (Target == 1 && Player1stats.Faint == false)
        {
            Battletext.text = "Enemy attacks Player 1";
            yield return new WaitForSeconds(2f);
            faint = Player1stats.TakeDamage(EnemyStats.Atk);
            if (faint == true)
            {
                Destroy(GameObject.Find("BattlePlayer 1(Clone)"));
                Player1stats.Faint = true;
            }
        }
        else
            Target = 2;
        if (Target == 2 && Player2stats.Faint == false)
        {
            Battletext.text = "Enemy attacks Player 2";
            yield return new WaitForSeconds(2f);
            faint = Player2stats.TakeDamage(EnemyStats.Atk);
            if (faint == true)
            {
                Destroy(GameObject.Find("BattlePlayer 2(Clone)"));
                Player2stats.Faint = true;
            }
        }
        else if (Target == 2 && Player2stats.Faint == true)
        {
            Target = 3;
        }
        if (Target == 3 && Player3stats.Faint == false)
        {
            Battletext.text = "Enemy attacks Player 3";
            yield return new WaitForSeconds(2f);
            faint = Player3stats.TakeDamage(EnemyStats.Atk);
            if (faint == true)
            {
                Destroy(GameObject.Find("BattlePlayer 3(Clone)"));
                Player3stats.Faint = true;
            }
        }
        HUD.SetP1Health(Player1stats.hp);
        HUD.SetP2Health(Player2stats.hp);
        HUD.SetP3Health(Player3stats.hp);

        if (P1Block == true)
        {
            Player1stats.Def /= 10;
        }
        if (P2Block == true)
        {
            Player2stats.Def /= 10;
        }
        if (P3Block == true)
        {
            Player3stats.Def /= 10;
        }
        P1Block = false;
        P2Block = false;
        P3Block = false;

        if (Player1stats.Faint == false)
        {
            Player1Turn();
        }
        else if (Player2stats.Faint == false)
        {
            Player2Turn();
        }
        else if (Player3stats.Faint == false)
        {
            Player3Turn();
        }
        else
            StartCoroutine(BattleLose());
    }


    //Attached to the attack buttons and is called when one is pressed
    public void OnAttackButton(int Num)
    {
        HideAttackOptions();
        StartCoroutine(PlayerAttack(Num));
        return;
    }

    public void SetPlayerStats()
    {
        SetPlayer1Stats(Player1stats);
        SetPlayer2Stats(Player2stats);
        SetPlayer3Stats(Player3stats);
    }
    void Randomised(ref int HpAmount, ref int AtkAmount, ref int DefAmount, ref int LvlAmount)
    {
        HpAmount = Random.Range(5, 10);
        AtkAmount = Random.Range(1, 5);
        DefAmount = Random.Range(1, 5);
        LvlAmount = Random.Range(5, 10);
    }
    public void SetPlayer1Stats(Player1 Player1)
    {
        int HpAmount = 0;
        int AtkAmount = 0;
        int DefAmount = 0;
        int LvlAmount = 0;
        Randomised(ref HpAmount, ref AtkAmount, ref DefAmount, ref LvlAmount);
        //Assign the random stats to the players
        Player1.Lvl = LvlAmount;
        Player1.hp = (HpAmount * Player1.Lvl);
        Player1.Maxhp = Player1.hp;
        Player1.Atk = (AtkAmount * Player1.Lvl);
        Player1.Def = (DefAmount * Player1.Lvl);
    }
    public void SetPlayer2Stats(Player2 Player2)
    {
        int HpAmount = 0;
        int AtkAmount = 0;
        int DefAmount = 0;
        int LvlAmount = 0;
        Randomised(ref HpAmount, ref AtkAmount, ref DefAmount, ref LvlAmount);
        //Assign the random stats to the players
        Player2.Lvl = LvlAmount;
        Player2.hp = (HpAmount * Player2.Lvl);
        Player2.Maxhp = Player2.hp;
        Player2.Atk = (AtkAmount * Player2.Lvl);
        Player2.Def = (DefAmount * Player2.Lvl);
    }
    public void SetPlayer3Stats(Player3 Player3)
    {
        int HpAmount = 0;
        int AtkAmount = 0;
        int DefAmount = 0;
        int LvlAmount = 0;
        Randomised(ref HpAmount, ref AtkAmount, ref DefAmount, ref LvlAmount);
        //Assign the random stats to the players
        Player3.Lvl = LvlAmount;
        Player3.hp = (HpAmount * Player3.Lvl);
        Player3.Maxhp = Player3.hp;
        Player3.Atk = (AtkAmount * Player3.Lvl);
        Player3.Def = (DefAmount * Player3.Lvl);
    }
    public void SetEnemyStats(Enemystats enemy)
    {
        int HpAmount = Random.Range(5, 10);
        int AtkAmount = Random.Range(1, 5);
        int DefAmount = Random.Range(1, 5);
        int LvlAmount = Random.Range(5, 20);
        //Assign the random stats to the Enemy
        enemy.Lvl = LvlAmount;
        enemy.Hp = (HpAmount * enemy.Lvl);
        enemy.MaxHp = enemy.Hp;
        enemy.Atk = (AtkAmount * enemy.Lvl);
        enemy.Def = (DefAmount * enemy.Lvl);
    }
    public void HideAttackOptions()
    {
        // Hide Move selection buttons
        GameObject.Find("Attack 1").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Attack 2").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Attack 3").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Attack 4").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Quit").transform.localScale = new Vector3(0, 0, 0);
    }
    public void ShowAttackOptions()
    {
        // Show Move selection buttons
        GameObject.Find("Attack 1").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Attack 2").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Attack 3").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Attack 4").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Quit").transform.localScale = new Vector3(1, 1, 1);
    }
    public void ShowOtherButtons()
    {
        //Show the starting buttons
        GameObject.Find("Battle").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("RunAway").transform.localScale = new Vector3(1, 1, 1);
    }
    public void HideOtherButtons()
    {
        //Hide the starting buttons
        GameObject.Find("Battle").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("RunAway").transform.localScale = new Vector3(0, 0, 0);
    }
    public void Fight()
    {
        //Swaps between the 2 when hitting battle
        ShowAttackOptions();
        HideOtherButtons();
    }
    public void Quit()
    {
        //Swaps back to the starting buttons
        HideAttackOptions();
        ShowOtherButtons();
    }
    IEnumerator BattleWin()
    {
        //Checks if the player has defeeated all the enemies and then either end the game or sends the player back to the Overworld
        Battletext.text = "Your Party Wins!";
        yield return new WaitForSeconds(4f);

        Variables.EnemiesToKill -= 1;

        bool LevelWin = CheckEnemiesLeft();
        if (LevelWin == true)
        {
            Battletext.text = "Youve killed the amount need!";
            yield return new WaitForSeconds(2f);
            Battletext.text = "You Win!";
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        else
            Battletext.text = "There are still more left!";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    IEnumerator BattleLose()
    {
        //End the game
        Battletext.text = "All Players are dead!";
        yield return new WaitForSeconds(2f);
        Battletext.text = "You Lose!";
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    bool CheckEnemiesLeft()
    {
        if (Variables.EnemiesToKill <= 0)
        {
            return true;
        }
        else
            return false;
    }
    public void BattleEnd()
    {
        //Run from the battle
        StartCoroutine(RunAway());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    IEnumerator RunAway()
    {
        Battletext.text = "You run away!";
        yield return new WaitForSeconds(4f);
    }
}

