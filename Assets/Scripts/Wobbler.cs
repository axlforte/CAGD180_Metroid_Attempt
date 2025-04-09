using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobbler : enemy
{
    public int speed;
    public int dir;
    float wobbleTimer = 0;

    // Update is called once per frame
    void Update()
    {
        wobbleTimer += Time.deltaTime;
        transform.position += Vector3.right * dir * speed * Time.deltaTime;

        if (!Physics.Raycast(transform.position + new Vector3(0.5f, 0, 0) * dir, Vector3.down, 1) || Physics.Raycast(transform.position + new Vector3(0.5f,0,0) * dir, Vector3.right * dir, 0.1f))
        {
            dir *= -1;
        }
    }
}
