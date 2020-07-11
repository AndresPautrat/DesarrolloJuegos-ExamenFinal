using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cream : MonoBehaviour
{
    float velocidad = 3;
    Rigidbody2D rigidbody;
    private float elapsed = 0;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (elapsed < 1)
        {
            elapsed += Time.deltaTime;
        }
        else
        {
            rigidbody.velocity = new Vector2(0f, velocidad);
        }
    }
}
