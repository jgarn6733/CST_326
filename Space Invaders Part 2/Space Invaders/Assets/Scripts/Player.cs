using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;
    public GameObject scoreGO;
    public TextMeshProUGUI scoreText;
    public GameObject hiScoreGO;
    public TextMeshProUGUI hiScoreText;
    public static GameObject player;
    public static GameObject GameManager;
    public AudioSource explosionSrc;
    public AudioSource shootingSrc;
    public ParticleSystem shootParticle;
    public float speed = 10f;
    public float maxSpeed = 10f;
    int score = 0;
    int hiScore;

    private void Start()
    {
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
        
        scoreGO = GameObject.Find("Score");
        scoreText = scoreGO.GetComponent<TextMeshProUGUI>();
        hiScoreGO = GameObject.Find("Hi-Score");
        hiScoreText = hiScoreGO.GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player");

        hiScore = PlayerPrefs.GetInt("hiScore", 0);

        GameManager = GameObject.Find("GameManager");
        shootParticle = GetComponent<ParticleSystem>();
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
        
        GetComponent<Animator>().SetTrigger("onShoot");
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        shootingSrc.Play();
            shootParticle.Play();
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
        float horizontalMovement = Input.GetAxis("Horizontal");
        Transform t = GetComponent<Transform>();
        if (horizontalMovement < 0)
        {
            t.Translate(Vector3.left / speed);
        } else if (horizontalMovement > 0)
        {
            t.Translate(Vector3.right / speed);
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
        GetComponent<Animator>().SetTrigger("onExplode");
        explosionSrc.Play();
        StartCoroutine(CallCredits());
        StopCoroutine(CallCredits());
        //Destroy(gameObject, 2.0f);

    }

    IEnumerator CallCredits()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        GameManager.GetComponent<GameManager>().StartCredits();
    }

    static void Respawn()
    {
        Instantiate(player, new Vector3(0f, -3.04f, 0f), Quaternion.identity);
    }


}
