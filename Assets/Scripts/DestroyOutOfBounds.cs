using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float lowerBound = -5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
