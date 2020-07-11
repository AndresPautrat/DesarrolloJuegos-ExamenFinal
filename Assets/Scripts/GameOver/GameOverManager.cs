using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    GameObject textScore;
    string level;
    int score;
    private float elapsed = 0;
    void Start()
    {
        if (PlayerPrefs.GetInt("vidas") == 1)
        {
            level = "parao";
        }
        else
        {
            level = "normal";
        }
        score = PlayerPrefs.GetInt(level);
        textScore.GetComponent<Text>().text = "Scores(" + level + "): " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsed < 3)
        {
            elapsed += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
