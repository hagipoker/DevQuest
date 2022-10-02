using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameData : Singleton<GameData>
{
    private float highscore;

    public float finish_time()
    {
        highscore = PlayerPrefs.GetFloat("highscore");

        return highscore;
    }
}
