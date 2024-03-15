using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeController : MonoBehaviour
{
    public ParticleSystem destroyParticle;
    // Start is called before the first frame update
    void Start()
    {
        destroyParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        destroyParticle.Play();
        Destroy(collision.gameObject);
        Destroy(gameObject, 1.0f);
        Debug.Log("barricade hit");
    }
}
