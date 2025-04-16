using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
