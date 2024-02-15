using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RightScore : MonoBehaviour
{
    public TextMeshProUGUI RightScoreText;
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
        RightScoreText.color = color ? Color.blue : Color.green;
        RightScoreText.text = score.ToString();
    }
}
