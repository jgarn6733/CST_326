using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeftScore : MonoBehaviour
{
    public TextMeshProUGUI LeftScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score, bool color)
    {
        LeftScoreText.color = color ? Color.blue : Color.red;
        LeftScoreText.text = score.ToString();

    }
}
