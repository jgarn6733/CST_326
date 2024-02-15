using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smaller : MonoBehaviour
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
        gameManager.Smaller();
        Destroy(GameObject.Find("Smaller(Clone)"));
    }
}
