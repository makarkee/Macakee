using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menulist : MonoBehaviour
{
    public static int score = 0;

    public GameObject menuList;//²Ëµ¥ÁÐ±í

    [SerializeField] private bool menuKeys = true;
    // Update is called once per frame
    void Update()
    {
        if (menuKeys)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(true);
                menuKeys = false;
                Time.timeScale = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            menuList.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1;
        }
    }

    public void Return()
    {
        menuList.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
