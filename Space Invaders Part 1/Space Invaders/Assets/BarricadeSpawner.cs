using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeSpawner : MonoBehaviour
{
    public GameObject barricade;
    public Transform BarricadeSpawnerTransform;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(barricade, new Vector3(-7f, 0f, 0f), Quaternion.identity, BarricadeSpawnerTransform);
        Instantiate(barricade, new Vector3(-2f, 0f, 0f), Quaternion.identity, BarricadeSpawnerTransform);
        Instantiate(barricade, new Vector3(3f, 0f, 0f), Quaternion.identity, BarricadeSpawnerTransform);
        Instantiate(barricade, new Vector3(8f, 0f, 0f), Quaternion.identity, BarricadeSpawnerTransform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
