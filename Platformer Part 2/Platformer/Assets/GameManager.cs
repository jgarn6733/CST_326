using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinsText;
    public Material brickMaterial;
    public Material questionMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int intTime = 400 - (int)Time.realtimeSinceStartup;
        string timeStr = $"Time \n {intTime}";
        timerText.text = timeStr;
        string coinsStr;

        int coins = 0;

        if (Input.GetMouseButtonDown(0))
        {
            Ray origin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool hit = Physics.Raycast(origin, out raycastHit, 100f);
            if (hit)
            {
                Material material = raycastHit.collider.GetComponent<Material>();
                if (material = brickMaterial)
                {
                    GameObject obj = GameObject.Find(raycastHit.collider.name);
                    Object.Destroy(obj);
                } else if (material == questionMaterial)
                {
                    coins++;
                    if (coins > 10)
                    {
                        coinsStr = $"Coins x0{coins}";
                    } else
                    {
                        coinsStr = $"Coins x{coins}";
                    }
                    Debug.Log(coinsStr);
                    coinsText.text = coinsStr;
                }
            }
        }
    }
}
