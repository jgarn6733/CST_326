using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.SpeedUp();
        Destroy(GameObject.Find("SpeedUp(Clone)"));
    }
}
