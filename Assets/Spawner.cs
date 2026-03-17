using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float recycleX = -20f;
    [SerializeField] private float segmentWidth = 20f; // width of the whole ground segment
    [SerializeField] private int totalSegments = 8;

    void Update()
    {
        if (transform.position.x <= recycleX)
        {
            transform.position = new Vector3(
                transform.position.x + (segmentWidth * totalSegments),
                transform.position.y,
                transform.position.z
            );
        }
    }
}


