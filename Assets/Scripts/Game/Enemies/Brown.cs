using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brown : MonoBehaviour
{
    // Start is called before the first frame update
    float velocidad = -3;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(0f, velocidad);
    }
}
