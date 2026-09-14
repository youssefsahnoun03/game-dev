using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rator : MonoBehaviour
{
    public float rotationSpeed = 200f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); // Rotate around Y axis
    }
}

