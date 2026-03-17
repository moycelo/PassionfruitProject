using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    [SerializeField]float scrollSpeed = 6f;

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
    }
}
