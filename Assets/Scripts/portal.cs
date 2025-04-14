using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform TPPoint;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = TPPoint.position;
    }
}