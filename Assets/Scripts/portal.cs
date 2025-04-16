using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Alexander Lara,
 * last updated: 4/16/2025
 * Teleports the player to a destination object upon collision unless if the door is locked anc can only be used if player has heavy bullets and the jump upgrade
 */

public class Portal : MonoBehaviour
{
    public Transform TPPoint;

    public bool locked;

    private void OnTriggerEnter(Collider other)
    {
        if(!locked)
        {
            other.transform.position = TPPoint.position;
        }
        else if(other.GetComponent<PlayerController>().hasHeavyBullet == true && other.GetComponent<PlayerController>().jumpForce == 12)
        {
            other.transform.position = TPPoint.position;
        }
    }
}