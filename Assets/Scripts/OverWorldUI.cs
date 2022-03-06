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
        EnemiesLeftToKill.text = (Variables.EnemiesToKill.ToString() + "Enemies left to kill");
    }
    public void OnPauseButton()
    {

        GameObject.Find("PauseEffect").transform.localScale = new Vector3(19.2f, 10f, 0);
        GameObject.Find("PauseText").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("PauseButton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("PlayButton").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Exit").transform.localScale = new Vector3(3, 3, 3);
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
