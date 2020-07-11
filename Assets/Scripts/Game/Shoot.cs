using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 bulletDirection;
    Rigidbody2D rigidbody;
    private float elapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = bulletDirection;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == other.gameObject.tag)
        {
            other.gameObject.SetActive(false);
            GameObject player = GameObject.FindGameObjectWithTag("Pla");
            switch (tag)
            {
                case "Red":
                    player.GetComponent<PlayerScript>().puntuacion += 10;
                    break;
                case "Yellow":
                    player.GetComponent<PlayerScript>().puntuacion += 15;
                    break;
                case "Fly":
                    player.GetComponent<PlayerScript>().puntuacion += 50;
                    break;
                case "Brown":
                    player.GetComponent<PlayerScript>().puntuacion += 5;
                    break;
                case "Cream":
                    player.GetComponent<PlayerScript>().puntuacion += 20;
                    break;
            }

        }
        gameObject.SetActive(false);
    }
}
