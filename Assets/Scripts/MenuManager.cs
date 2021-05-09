using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;

    public Button restartBtn;
    public Button returnBtn;

    private bool menuState = false;

    public void RestartScene()
    {
        Debug.Log("RestartScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToScene()
    {
        Debug.Log("ReturnToScene");
        menuState = !menuState;
        menu.SetActive(menuState);

        //continue game
        Time.timeScale = 1;
    }

    void Start()
    {
        menu.SetActive(menuState);

        restartBtn.onClick.AddListener(RestartScene);
        returnBtn.onClick.AddListener(ReturnToScene);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            //pause game
            Time.timeScale = 0;

            ReturnToScene();
        }
    }
}