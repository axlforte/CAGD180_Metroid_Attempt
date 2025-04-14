using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float health = 1;
    public float invulnTime = 0;
    public float invulnTimeDefault = 0;

    // i am using fixedupdate so regular update can still be called by enemies. i could also have an enemyupdate function but that would be odd
    void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        invulnTime = Mathf.Clamp(invulnTime - 1, 0, 99999);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BlastProjectileScript>() && invulnTime <= 0)
        {
            invulnTime = invulnTimeDefault;
            health -= other.GetComponent<BlastProjectileScript>().basedamage;
        }
    }
}
