using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameEnd : MonoBehaviour
{
    private bool gameEnd = false;
    private float time;
    private float fin_time;
    public static float highscore;
    public TextMeshProUGUI highscore_text;

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore");
    }

    void Update()
    {
        var targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets.Length == 0)
        {
            gameEnd = true;
            EndGame();
        }
        time += Time.deltaTime;
        highscore_text.text = "Highscore : " + $"{(PlayerPrefs.GetFloat("highscore")):N2}";
    }

    void EndGame()
    {
        fin_time = time;
        if ((PlayerPrefs.GetFloat("highscore") == 0) | (fin_time < highscore))
        {
            PlayerPrefs.SetFloat("highscore", fin_time);
        }
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(1);
    }

    public bool IsGameEnd()
    {
        return gameEnd;
    }
}
