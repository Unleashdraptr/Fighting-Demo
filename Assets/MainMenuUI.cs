using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    MapGenerator mapGenerator;
    public GameObject Start;
    public GameObject Levels;
    public GameObject RandomWorld;
    public GameObject Exit;
    public GameObject Return;
    public GameObject Level;
    GameObject SeedTransfer;
    int[] SeedLvl = { -42069, -69420, 69420, 42069, 69, 5687, -61053, -47870, 17933, -43301 };
    int[] LvlNumber = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21,22,23,24 };
    int[] Xoffset = { -100, 150, 400, 650, 900, 1150, 1400, 1650, -100, 150, 400, 650, 900, 1150, 1400, 1650, -100, 150, 400, 650, 900, 1150, 1400, 1650 };
    int[] Yoffset = { 200, 200, 200, 200, 200, 200, 200, 200, 400, 400, 400, 400, 400, 400, 400, 400, 600, 600, 600, 600, 600, 600, 600, 600 };
    public void StartPress()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(GameObject.Find("Start(Clone)"));
        Destroy(GameObject.Find("Exit(Clone)"));
        Instantiate(Levels, new Vector3(950, 635, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        Instantiate(RandomWorld, new Vector3(950, 75, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        Instantiate(Return, new Vector3(1700, 45, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);

    }
    public void QuitOnPress()
    {
       
    }
    public void LoadLvlButtons()
    {
        Destroy(GameObject.Find("Levels(Clone)"));
        Destroy(GameObject.Find("RandomWorld(Clone)"));
        GameObject.Find("Levels").transform.localScale = new Vector3(3, 3, 1);
    }
    public void RandomWorldButton()
    {
        Variables.random = true;
        Variables.SeedNumber = Random.Range(-100000, 100000);
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
        Variables.SeedNumber = SeedLvl[(LvlNum - 1)];
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
