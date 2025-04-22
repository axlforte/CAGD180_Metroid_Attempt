using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Alexander Lara
 * last updated: 4/16/2025
 * Begins flying in the direction the player is facing and destroys self upon colision with anything
 */

public class HeavyBlastProjectileScript : BlastProjectileScript
{
    void Start()
    {
        basedamage = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (facingLeft == true)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
        }
    }
}
