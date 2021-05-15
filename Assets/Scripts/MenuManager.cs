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
        
        menuState = false;
        Time.timeScale = 1;
    }

    public void ReturnToScene()
    {
        Debug.Log("ReturnToScene");
        
        menuState = false;
        menu.SetActive(menuState);

        //continue game
        Time.timeScale = 1;
    }

    public void OpenMenu()
    {
        Debug.Log("OpenMenu");

        menuState = true;
        menu.SetActive(menuState);

        Time.timeScale = 0;
    }


    void Start()
    {
        menu.SetActive(menuState);

        restartBtn.onClick.AddListener(RestartScene);
        returnBtn.onClick.AddListener(ReturnToScene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            if (!menuState) //menu state is false
            {
                OpenMenu();
            }
            else
            {
                ReturnToScene();
            }
        }
    }
}