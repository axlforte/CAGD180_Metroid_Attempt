using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * by Davis
 * 4/16/25
 * makes basic enemies move around and flash when invincible
 * */
public class Wobbler : enemy
{
    public int speed;
    public int dir;
    float wobbleTimer = 0;
    public LayerMask lm;
    public float beamlength = 1;
    public Renderer rend;
    public Material normal, stunned;

    void awake()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        wobbleTimer += Time.deltaTime;
        transform.position += Vector3.right * dir * speed * Time.deltaTime;

        if (!Physics.Raycast(transform.position + new Vector3(0.5f, 0, 0) * dir, Vector3.down, beamlength, lm) || Physics.Raycast(transform.position + new Vector3(0.5f,0,0) * dir, Vector3.right * dir, 0.1f, lm))
        {
            dir *= -1;
        }

        if (invulnTime % 2 == 1)
        {
            rend.material = stunned;
        } else
        {
            rend.material = normal;
        }
    }
}
