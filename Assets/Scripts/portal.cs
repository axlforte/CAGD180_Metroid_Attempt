using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        else if(other.GetComponent<PlayerController>().hasHeavyBullet == true && other.GetComponent<PlayerController>().jumpForce == 10)
        {
            other.transform.position = TPPoint.position;
        }
    }
}