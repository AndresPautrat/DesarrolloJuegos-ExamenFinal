using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedYellow : MonoBehaviour
{
    public float velocidad = -2;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(velocidad, 0f);
    }
}
