using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float health = 1;
    public float invulnTime = 0;
    public float invulnTimeDefault = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BlastProjectileScript>())
        {
            invulnTime = invulnTimeDefault;
            health -= other.GetComponent<BlastProjectileScript>().basedamage;
        }
    }
}
