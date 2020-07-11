using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    int numPrefabs = 15;
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
    float minX;
    float maxX;
    float minY;
    int stage = 1;
    float maxY;
    private float elapsed = 0;
    float spawnTime = 8f;
    int spawnedEnemies = 0;
    void Start()
    {
        float heigh = Camera.main.orthographicSize * 2f;
        float width = heigh * Screen.width / Screen.height;
        minX = -width / 2;
        maxX = width / 2;
        minY = -heigh / 2;
        maxY = heigh / 2;

        for (int i = 0; i < numPrefabs; i++)
        {
            GameObject instance;

            instance = Instantiate(prefRed, new Vector3(maxX + 50, minY - 100), Quaternion.identity);
            instance.gameObject.SetActive(false);
            Reds.Add(instance);

            instance = Instantiate(prefYellow, new Vector3(maxX + 50, minY - 100), Quaternion.identity);
            instance.gameObject.SetActive(false);
            Yellows.Add(instance);

            instance = Instantiate(prefFly, new Vector3(maxX + 50, minY - 100), Quaternion.identity);
            instance.gameObject.SetActive(false);
            Flys.Add(instance);

            instance = Instantiate(prefBrown, new Vector3(maxX + 50, minY - 100), Quaternion.identity);
            instance.gameObject.SetActive(false);
            Browns.Add(instance);

            instance = Instantiate(prefCream, new Vector3(maxX + 50, minY - 100), Quaternion.identity);
            instance.gameObject.SetActive(false);
            Creams.Add(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (spawnedEnemies)
        {
            case 4:
                stage = 2;
                spawnTime = 6f;
                break;
            case 12:
                stage = 3;
                spawnTime = 4f;
                break;
            case 38:
                stage = 4;
                spawnTime = 3f;
                break;
            case 70:
                stage = 5;
                spawnTime = 2f;
                break;
        }

        elapsed += Time.deltaTime;
        if (elapsed >= spawnTime)
        {
            spawnedEnemies++;
            int type = Random.Range(0, stage);
            switch (type)
            {
                case 0:
                    //red
                    generateRed();
                    break;
                case 1:
                    //yellow
                    generateYellow();
                    break;
                case 2:
                    generateFly();
                    //fly
                    break;
                case 3:
                    generateBrown();
                    //brown
                    break;
                case 4:
                    generateCream();
                    //cream
                    break;

            }
            elapsed = 0;
        }
    }

    void generateRed()
    {
        for (int i = 0; i < 30; i++)
        {
            int index = Random.Range(0, numPrefabs - 1);
            if (!Reds[index].active)
            {

                Reds[index].gameObject.SetActive(true);
                if (Random.Range(0, 2) != 0)
                {
                    Reds[index].transform.position = new Vector2(maxX + 1, minY + 1);
                    Reds[index].GetComponent<RedYellow>().velocidad = -2;
                }
                else
                {
                    Reds[index].transform.position = new Vector2(minX - 1, minY + 1);
                    Reds[index].GetComponent<RedYellow>().velocidad = 2;
                }
                break;
            }
        }
    }
    void generateYellow()
    {
        for (int i = 0; i < 30; i++)
        {
            int index = Random.Range(0, numPrefabs - 1);
            if (!Yellows[index].active)
            {

                Yellows[index].gameObject.SetActive(true);
                if (Random.Range(0, 2) != 0)
                {
                    Yellows[index].transform.position = new Vector2(maxX + 1, minY + 1);
                    Yellows[index].GetComponent<RedYellow>().velocidad = -2;
                }
                else
                {
                    Yellows[index].transform.position = new Vector2(minX - 1, minY + 1);
                    Yellows[index].GetComponent<RedYellow>().velocidad = 2;
                }
                break;
            }
        }
    }
    void generateFly()
    {
        for (int i = 0; i < 30; i++)
        {
            int index = Random.Range(0, numPrefabs - 1);
            if (!Flys[index].active)
            {

                Flys[index].gameObject.SetActive(true);
                if (Random.Range(0, 2) != 0)
                {
                    Flys[index].transform.position = new Vector2(maxX + 1, 0);
                    Flys[index].GetComponent<Fly>().velocidad = -2;
                }
                else
                {
                    Flys[index].transform.position = new Vector2(minX - 1, 0);
                    Flys[index].GetComponent<Fly>().velocidad = 2;
                }
                break;
            }
        }
    }

    void generateBrown()
    {
        for (int i = 0; i < 30; i++)
        {
            int index = Random.Range(0, numPrefabs - 1);
            if (!Browns[index].active)
            {
                Browns[index].gameObject.SetActive(true);
                Browns[index].transform.position = new Vector2(Random.Range(minX, maxX), maxY + 1);
                break;
            }
        }
    }
    void generateCream()
    {
        for (int i = 0; i < 30; i++)
        {
            int index = Random.Range(0, numPrefabs - 1);
            if (!Creams[index].active)
            {
                Creams[index].gameObject.SetActive(true);
                Creams[index].transform.position = new Vector2(Random.Range(minX, maxX), minY);
                break;
            }
        }
    }

}
