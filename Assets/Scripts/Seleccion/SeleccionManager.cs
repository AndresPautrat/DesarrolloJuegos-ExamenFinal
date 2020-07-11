using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeleccionManager : MonoBehaviour
{
    [SerializeField]
    Button normalBtn;
    [SerializeField]
    Button paraoBtn;
    // Start is called before the first frame update
    void Start()
    {
        normalBtn.onClick.AddListener(() => normalGame());
        paraoBtn.onClick.AddListener(() => paraoGame());
    }

    void normalGame()
    {
        PlayerPrefs.SetInt("vidas", 4);
        SceneManager.LoadScene("Game");
    }
    void paraoGame()
    {
        PlayerPrefs.SetInt("vidas", 1);
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
