using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class BlastProjectileScript : MonoBehaviour
{
    public float speed;
    public bool facingLeft;

    public float basedamage = 1;

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
}
