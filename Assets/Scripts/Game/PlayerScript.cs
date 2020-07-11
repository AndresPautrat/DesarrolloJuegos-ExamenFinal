using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    int numPrefabs = 15;
    Vector2 bulletDirection = new Vector2(5f, 0f);
    [SerializeField]
    GameObject prefRed;
    List<GameObject> Reds = new List<GameObject>();
    [SerializeField]
    GameObject prefYellow;
    List<GameObject> Yellows = new List<GameObject>();
    [SerializeField]
    GameObject prefFly;
    List<GameObject> Flys = new List<GameObject>();

    [SerializeField]
    GameObject prefBrown;
    List<GameObject> Browns = new List<GameObject>();
    [SerializeField]
    GameObject prefCream;
    List<GameObject> Creams = new List<GameObject>();

    [SerializeField]
    GameObject textVidas;
    [SerializeField]
    GameObject textPuntuacion;
    int vidas = 4;
    public int puntuacion = 0;
    string level;
    Rigidbody2D rigidbody;
    private Rigidbody2D rb;
    Rigidbody2D body;
    float minX;
    float maxX;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        float heigh = Camera.main.orthographicSize * 2f;
        float width = heigh * Screen.width / Screen.height;
        minX = -width / 2;
        maxX = width / 2;

        animator = GetComponent<Animator>();

        vidas = PlayerPrefs.GetInt("vidas");
        rigidbody = GetComponent<Rigidbody2D>();
        if (vidas == 1)
        {
            level = "parao";
        }
        else
        {
            level = "normal";
        }

        for (int i = 0; i < numPrefabs; i++)
        {
            GameObject instance;

            instance = Instantiate(prefRed, new Vector3(maxX + 50, -100), Quaternion.identity);
            instance.gameObject.SetActive(false);
            Reds.Add(instance);

            instance = Instantiate(prefYellow, new Vector3(maxX + 50, -100), Quaternion.identity);
            instance.gameObject.SetActive(false);
            Yellows.Add(instance);

            instance = Instantiate(prefFly, new Vector3(maxX + 50, -100), Quaternion.identity);
            instance.gameObject.SetActive(false);
            Flys.Add(instance);

            instance = Instantiate(prefBrown, new Vector3(maxX + 50, -100), Quaternion.identity);
            instance.gameObject.SetActive(false);
            Browns.Add(instance);

            instance = Instantiate(prefCream, new Vector3(maxX + 50, -100), Quaternion.identity);
            instance.gameObject.SetActive(false);
            Creams.Add(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        textPuntuacion.GetComponent<Text>().text = puntuacion.ToString();
        textVidas.GetComponent<Text>().text = vidas.ToString();
        if (vidas == 0)
        {
            PlayerPrefs.SetInt(level, puntuacion);
            SceneManager.LoadScene("GameOver");
        }
        if (transform.position.x > maxX)
            transform.position = new Vector3(maxX, transform.position.y, 1);
        else if (transform.position.x < minX)
            transform.position = new Vector3(minX, transform.position.y, 1);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rigidbody.velocity.x < 2)
            {
                rigidbody.AddForce(new Vector2(50f, 0f));
                bulletDirection = new Vector2(5f, 0f);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rigidbody.velocity.x > -2)
            {
                rigidbody.AddForce(new Vector2(-50f, 0f));
                bulletDirection = new Vector2(-5f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (rigidbody.velocity.y < 2 && transform.position.y < -3f)
            {
                print(transform.position.y);
                rigidbody.AddForce(new Vector2(0f, 400f));
                bulletDirection = new Vector2(0f, 5f);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            print(transform.position.y);
            rigidbody.AddForce(new Vector2(0f, -50f));
            bulletDirection = new Vector2(0f, -5f);
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            generateBullet(Reds);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            generateBullet(Yellows);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            generateBullet(Flys);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            generateBullet(Browns);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            generateBullet(Creams);
        }


        if (rigidbody.velocity.x > 0)
        {
            if (rigidbody.velocity.y != 0)
            {
                animator.Play("PlayerJumpRight");
            }
            else
            {
                animator.Play("PlayerRunRigth");
            }
        }
        else if (rigidbody.velocity.x < 0)
        {
            if (rigidbody.velocity.y != 0)
            {
                animator.Play("PlayerJumpLeft");
            }
            else
            {
                animator.Play("PlayerRunLeft");
            }
        }
        else
        {
            animator.Play("PlayerIdle");
        }
    }

    void generateBullet(List<GameObject> Bullets)
    {
        for (int i = 0; i < 30; i++)
        {
            int index = Random.Range(0, numPrefabs - 1);
            if (!Bullets[index].active)
            {
                Bullets[index].gameObject.SetActive(true);
                Bullets[index].transform.position = transform.position;
                Bullets[index].GetComponent<Shoot>().bulletDirection = bulletDirection;
                break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Red" || other.gameObject.tag == "Yellow" || other.gameObject.tag == "Brown" || other.gameObject.tag == "Fly" || other.gameObject.tag == "Cream")
        {
            vidas--;
            other.gameObject.SetActive(false);
        }
    }
}
