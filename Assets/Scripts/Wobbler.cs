using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobbler : MonoBehaviour
{
    public int speed;
    public int dir;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<shotScript>())
        {
            health -= other.GetComponent<shotScript>().damage;
        }
    }
}
