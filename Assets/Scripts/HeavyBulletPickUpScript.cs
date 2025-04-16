using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Alexander Lara
 * last updated: 4/16/2025
 * Upon collsion with the player, set the player's "hasHeavyBullet" variable to true and destroy self
 */
public class HeavyBulletPickUpScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().hasHeavyBullet = true;
            Destroy(gameObject);
        }
    }
}
