using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    private float highscore;
    public TextMeshProUGUI highscore_text;
    
    void GetGameData()
    {
        highscore = GameData.Instance.finish_time();
        ShowGameData();
    }

    void ShowGameData()
    {
        highscore_text.text = "Highscore : " + $"{highscore:N2}";
    }

    void Update()
    {
        GetGameData();
    }
}
