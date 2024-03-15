using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGridManager : MonoBehaviour
{
    public GameObject enemyRed;
    public GameObject enemyGreen;
    public GameObject enemyWhite;
    public GameObject enemyPurple;
    public Transform EnemyGrid;
    public GameObject AlienBullet;
    public AudioSource shootingSrc;
    GameObject[] enemies;
    public static int enemiesDestroyed = 0;
    public static float speed = 0.1f;
 
    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[10];
        Enemy.OnEnemyDied += CalculateSpeed;
        Vector3 startPos = transform.position;
        Vector3 spawnPos = transform.position;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                spawnPos.x = startPos.x + j;
                spawnPos.y = startPos.y - i;
                if (i == 0)
                {
                    GameObject enemy = Instantiate(enemyRed, spawnPos, Quaternion.identity, EnemyGrid);
                    enemies[j] = enemy;
                } else if (i > 0 && i < 3)
                {
                    Instantiate(enemyGreen, spawnPos, Quaternion.identity, EnemyGrid);
                } else
                {
                    Instantiate(enemyWhite, spawnPos, Quaternion.identity, EnemyGrid);
                }
            }
        }
        InvokeRepeating("chooseAlien", 10f, 30f);

    }

    // Update is called once per frame
    void Update()
    {
        /* This is my code that attempts to move the grid of enemies, but it just goes right and then all the way down.
        int leftx = -8;
        int rightx = 0;
        bool goRight = true;
        if (EnemyGrid.position.x < rightx && goRight)
        {
            EnemyGrid.position = EnemyGrid.position + new Vector3(speed, 0, 0);
        } else if (EnemyGrid.position.x >= rightx && goRight)
        {
            goRight = false;
            EnemyGrid.position = EnemyGrid.position - new Vector3(0, 1, 0);
            EnemyGrid.position = EnemyGrid.position - new Vector3(speed, 0, 0);
        } else if (EnemyGrid.position.x > leftx && !goRight)
        {
            EnemyGrid.position = EnemyGrid.position - new Vector3(speed, 0, 0);
        } else if (EnemyGrid.position.x <= leftx && !goRight)
        {
            goRight = true;
            EnemyGrid.position = EnemyGrid.position - new Vector3(0, 1, 0);
            EnemyGrid.position = EnemyGrid.position + new Vector3(speed, 0, 0);
        } else if (EnemyGrid.position.x < rightx && !goRight)
        {
            EnemyGrid.position = EnemyGrid.position - new Vector3(speed, 0, 0);
        } else if (EnemyGrid.position.x > leftx && goRight)
        {
            EnemyGrid.position = EnemyGrid.position + new Vector3(speed, 0, 0);
        }
        */

        
    }

    void CalculateSpeed(int pointsWorth)
    {
        enemiesDestroyed++;
        if (enemiesDestroyed == 20)
        {
            speed = 0.2f;
        } if (enemiesDestroyed == 40)
        {
            speed = 0.3f;
        }
    }

    void chooseAlien()
    {
        int randomNum = Random.Range(0, 10);
        while (enemies[randomNum] == null)
        {
            randomNum = Random.Range(0, 10);
        }
        GameObject alien = enemies[randomNum];
        Vector3 alienPos = alien.transform.position;
        Vector3 shootOffset = alienPos - Vector3.up;
        GameObject shot = Instantiate(AlienBullet, shootOffset, Quaternion.identity);
        shootingSrc.Play();
        Destroy(shot, 3f);
    }
}
