using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * by Davis
 * 4/16/25
 * moves boss around in a specific motion and handles invuln flashing
 * */

public class boss : enemy
{
    public Transform[] travelPoints;
    public float speed;
    public float lerpPosition;
    public float lerpArrayPos;
    float PCount;
    public Renderer rend;
    public Material normal, stunned;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        PCount = (float)travelPoints.Length;
        //we dont need this to be dynamic unless we wanna go crazy with the boss
    }

    // Update is called once per frame
    void Update()
    {
        //i love casting an integer to a float just to cast said float into an integer
        transform.position = Vector3.Lerp(travelPoints[(int)(lerpArrayPos - 1.0f) % (int)PCount].position, travelPoints[(int)lerpArrayPos % (int)PCount].position, lerpPosition);
        lerpPosition += Time.deltaTime * speed;
        if(lerpPosition > 1)
        {
            lerpPosition -= 1f;
            lerpArrayPos++;
        }

        //do i hate myself enough to get all renderers on the object? no.
        //this flickers between the invulnerable material and the regular one. nothing major
        if (invulnTime % 2 == 1)
        {
            rend.material = stunned;
        }
        else
        {
            rend.material = normal;
        }
    }
}
