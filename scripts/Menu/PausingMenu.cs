using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausingMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public static bool isPaused;

    void Start()
    {
        menuPanel.SetActive(false);
        isPaused = false;
    }


    void Update()
    {
        if(isPaused)
        {
            Cursor.visible = true;
            Screen.lockCursor = false;
        }
        else
        {
            Cursor.visible = false;
            Screen.lockCursor = true;
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
        isPaused = false;
    }

    public void ResumeFunction()
    {
        ResumeGame();
    }

    public void MainMenuFunction()
    {
        PlayerPrefs.SetInt("gold", GlobalGold.goldValue);
        PlayerPrefs.SetInt("ammo", GlobalAmmo.handgunAmmo);
        PlayerPrefs.SetInt("currentLevel", GlobalLevel.currentLevel);
        SceneManager.LoadScene("Menu");
    }

    public void QuitFunction()
    {
        Application.Quit();
    }
}
