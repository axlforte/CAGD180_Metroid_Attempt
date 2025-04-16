using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Alexander Lara, Davis
 * last updated: 4/16/2025
 * Upon collsion with the player,set the player's "canBall" variable to true and display a message on the ui
 */

public class BallerPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().canBall = true;
            other.GetComponent<PlayerController>().UHandler.ShowMessageOnscreen("Press down to begin sliding");
            Destroy(gameObject);
        }
    }
}
