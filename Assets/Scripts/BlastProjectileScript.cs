using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class BlastProjectileScript : MonoBehaviour
{
    public float speed;
    public bool facingLeft;

    public LayerMask lm;
    public float basedamage = 1;
    public float grace = 0.25f;

    void Start()
    {
       StartCoroutine(Remove());
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

        if (grace > 0)
        {
            grace -= Time.deltaTime;
        }  else if(Physics.Raycast(transform.position + new Vector3(-0.5f, 0, 0), Vector3.right, 1, lm))
        {
            Destroy(gameObject);
        }
    }

    //a very accurate name for the projectile's system of automatically cleaning up after a certain amount of time
     IEnumerator Remove()
     {
         yield return new WaitForSeconds(2);
         Destroy(gameObject);
     } 

    void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
        }
    }
}
