using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
