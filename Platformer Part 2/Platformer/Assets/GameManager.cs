using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI scoreText;
    public Material brickMaterial;
    public Material questionMaterial;
    public static int score = 0;
    public static int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int intTime = 100 - (int)Time.realtimeSinceStartup;
        if (intTime == 0)
        {
            Debug.Log("Time up, game over");
        }
        string timeStr = $"Time \n {intTime}";
        timerText.text = timeStr;
        
    }

    public static void addScore(TextMeshProUGUI scoreText)
    {
        string scoreStr;
        score += 100;
        if (score < 1000)
        {
            scoreStr = $"Score \n 000{score}";
        } else if (score < 10000)
        {
            scoreStr = $"Score \n 00{score}";
        } else if (score < 100000)
        {
            scoreStr = $"Score \n 0{score}";
        } else
        {
            scoreStr = $"Score \n {score}";
        }
        scoreText.text = scoreStr;
    }

    public static void addCoins(TextMeshProUGUI scoreText, TextMeshProUGUI coinsText)
    {
        coins += 1;
        string coinsStr;
        if (coins < 10)
        {
            coinsStr = $"Coins \n x0{coins}";
        } else
        {
            coinsStr = $"Coins \n x{coins}";
        }
        coinsText.text = coinsStr;
        addScore(scoreText);
    }
}
