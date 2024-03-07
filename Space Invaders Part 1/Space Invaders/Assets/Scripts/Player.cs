using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;
    public TextMeshProUGUI scorecardText;
    public GameObject scorecardGO;
    public GameObject scoreGO;
    public TextMeshProUGUI scoreText;
    public GameObject hiScoreGO;
    public TextMeshProUGUI hiScoreText;
    public static GameObject player;
    public float speed = 10f;
    public float maxSpeed = 10f;
    bool hasShot = false;
    int score = 0;
    int hiScore;

    private void Start()
    {
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
        scorecardGO = GameObject.Find("Scorecard");
        scorecardText = scorecardGO.GetComponent<TextMeshProUGUI>();
        scoreGO = GameObject.Find("Score");
        scoreText = scoreGO.GetComponent<TextMeshProUGUI>();
        hiScoreGO = GameObject.Find("Hi-Score");
        hiScoreText = hiScoreGO.GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player");

        hiScore = PlayerPrefs.GetInt("hiScore", 0);
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
    }

    void EnemyOnOnEnemyDied(int pointsWorth)
    {
        Debug.Log($"player received 'EnemyDied' worth {pointsWorth} points");
        score += pointsWorth;
        if (score < 100)
        {
            scoreText.text = $"Score\n00{score}";
        } else if (score < 1000)
        {
            scoreText.text = $"Score\n0{score}";
        } else
        {
            scoreText.text = $"Score\n{score}";
        }
        

    }
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        if (!hasShot)
            {
                scorecardGO.SetActive(false);
                hasShot = true;
            }
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
        float horizontalMovement = Input.GetAxis("Horizontal");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity += Vector2.right * horizontalMovement * Time.deltaTime * speed;

        if (rb.velocity.x > maxSpeed)
        {
            Vector2 newVel = rb.velocity;
            newVel.x = maxSpeed;
            rb.velocity = newVel;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (score > hiScore)
        {
            PlayerPrefs.SetInt("hiScore", score);
            if (score < 100)
            {
                hiScoreText.text = $"Hi-Score\n00{score}";
            } else if (score < 1000)
            {
                hiScoreText.text = $"Hi-Score\n0{score}";
            } else
            {
                hiScoreText.text = $"Hi-Score\n{score}";
            }
            scoreText.text = "Score\n0000";
            
        }
        //Respawn();
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    static void Respawn()
    {
        Instantiate(player, new Vector3(0f, -3.04f, 0f), Quaternion.identity);
    }
}
