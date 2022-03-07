using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject Start;
    public GameObject Levels;
    public GameObject RandomWorld;
    public GameObject Exit;
    public GameObject Return;
    public GameObject Level;
    int[] SeedLvl = { 42069, 69420, 69, 5687, 61053, 47870, 17933, 43301, 84738, 59468, 75553, 74104, 72278, 1543, 1423, 764, 4224, 76546, 76574, 4321, 321, 2, 312, 543 };
    Vector3[] StartPos = { new Vector3(272, 9, 274), new Vector3(-63, 19, -302), new Vector3(156, 78, -455), new Vector3(0, 9, 0), new Vector3(886, 24, 232), new Vector3(-49, 139, -850), new Vector3(56, 3, -168), new Vector3(0, 10, 0), new Vector3(-117, 15, 613), new Vector3(157, 9, -112), new Vector3(571, 9, 573), new Vector3(-17, 148, -329), new Vector3(-280, 13, -378), new Vector3(-280, 15, 508), new Vector3(219, 18, 221), new Vector3(0, 50, 0), new Vector3(277, 90, -409), new Vector3(187, 5, 99), new Vector3(800, 10, 327), new Vector3(240, 10, 209), new Vector3(384, 10, -603), new Vector3(166, 25, -151), new Vector3(-364, 16, -846), new Vector3(166, 0, -301),new Vector3(-171,69,-33) };
    int[] EnemiesToWin = { 5, 8, 10, 12, 15, 18, 20, 22, 25, 28, 30, 32, 35, 40, 45, 50, 60, 70, 80, 90, 95, 100, 125, 150 };
    public void StartPress()
    {
        Destroy(GameObject.Find("Start(Clone)"));
        Destroy(GameObject.Find("Exit(Clone)"));
        Instantiate(Levels, new Vector3(550, 325, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        Instantiate(RandomWorld, new Vector3(550, 75, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        Instantiate(Return, new Vector3(950, 45, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
    }
    public void QuitOnPress()
    {
       
    }
    public void LoadLvlButtons()
    {
        Destroy(GameObject.Find("Levels(Clone)"));
        Destroy(GameObject.Find("RandomWorld(Clone)"));
        GameObject.Find("Levels").transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }
    public void RandomWorldButton()
    {
        Variables.random = true;
        Variables.SeedNumber = Random.Range(-100000, 100000);
        Variables.PlayerPos = new Vector3(0, 100, 0);
        Variables.FirstLoad = true;
        Variables.FirstBattle = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReturnPress()
    {
        Destroy(GameObject.Find("Levels(Clone)"));
        Destroy(GameObject.Find("RandomWorld(Clone)"));
        Destroy(GameObject.Find("Return(Clone)"));
        GameObject.Find("Levels").transform.localScale = new Vector3(0, 0, 0);
        Instantiate(Start, new Vector3(950, 435, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        Instantiate(Exit, new Vector3(950, 175, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);

    }
    public void LvlPress(int LvlNum)
    {
        Variables.random = false;
        Variables.SeedNumber = SeedLvl[LvlNum - 1];
        Variables.EnemiesToKill = EnemiesToWin[LvlNum - 1];
        Variables.PlayerPos = StartPos[LvlNum - 1];
        Variables.FirstLoad = true;
        Variables.FirstBattle = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
