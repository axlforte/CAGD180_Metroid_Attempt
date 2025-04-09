using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobbler : enemy
{
    public int speed;
    public int dir;
    public float health;
    float wobbleTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wobbleTimer += Time.deltaTime;
        transform.position += Vector3.right * dir * speed * Time.deltaTime;

        RaycastHit hit;

        if (!Physics.Raycast(transform.position + new Vector3(0.5f, 0, 0) * dir, Vector3.down, 1) || Physics.Raycast(transform.position + new Vector3(0.5f,0,0) * dir, Vector3.right * dir, 1))
        {
            dir *= -1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<shotScript>())
        {
            health -= other.GetComponent<shotScript>().damage;
        }
    }
}
