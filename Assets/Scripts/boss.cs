using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : enemy
{
    public Transform[] travelPoints;
    public float speed;
    public float lerpPosition;
    public float lerpArrayPos;
    float PCount;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
