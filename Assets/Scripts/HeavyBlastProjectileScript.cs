using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBlastProjectileScript : BlastProjectileScript
{
    public float speed;
    public bool facingLeft;

    public float basedamage = 3;

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
