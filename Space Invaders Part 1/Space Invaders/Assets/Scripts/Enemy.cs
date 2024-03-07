using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int points = 10;
    public delegate void EnemyDied(int pointsWorth);
    public static event EnemyDied OnEnemyDied;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
        Destroy(collision.gameObject);

        if (gameObject.name == "EnemyRed(Clone)")
        {
            points = 30;
        } else if (gameObject.name == "EnemyGreen(Clone)")
        {
            points = 20;
        } else if (gameObject.name == "EnemyWhite(Clone)")
        {
            points = 10;
        } else
        {
            points = 200;
        }
        OnEnemyDied.Invoke(points);
        Destroy(gameObject);
    }

}
