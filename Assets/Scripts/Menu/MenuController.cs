using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    Button jugarBtn;
    // Start is called before the first frame update
    void Start()
    {
        jugarBtn.onClick.AddListener(() => goGame());
    }

    void goGame()
    {
        SceneManager.LoadScene("Seleccion");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
