using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverWorldUI : MonoBehaviour
{
    public Text EnemiesLeftToKill;
    void Start()
    {
        EnemiesLeftToKill.text = " Enemies left to kill:" + Variables.EnemiesToKill.ToString();
        GameObject.Find("PauseEffect").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("PauseText").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("PauseButton").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("PlayButton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Exit").transform.localScale = new Vector3(0, 0, 0);
        Variables.Pause = false;
    }
    public void OnPauseButton()
    {

        GameObject.Find("PauseEffect").transform.localScale = new Vector3(10.8f, 5f, 0);
        GameObject.Find("PauseText").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("PauseButton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("PlayButton").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Exit").transform.localScale = new Vector3(2, 2, 2);
        Variables.Pause = true;

    }
    public void OnPlayButton()
    {
        GameObject.Find("PauseEffect").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("PauseText").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("PauseButton").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("PlayButton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Exit").transform.localScale = new Vector3(0, 0, 0);
        Variables.Pause = false;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
