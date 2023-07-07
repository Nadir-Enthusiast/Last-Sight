using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource clickSound;
    public GameObject fadeOut;
    
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        
    }

    void Update()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void NewGame()
    {
        StartCoroutine(NewGameRoutine());
    }

    IEnumerator NewGameRoutine()
    {
        clickSound.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("StartingWeapon", 1);
        PlayerPrefs.SetInt("currentLevel", 1);
        PlayerPrefs.SetString("WeaponsObtained", "1");
        PlayerPrefs.SetInt("health", 100);
        SceneManager.LoadScene(1);        
    }

    public void LoadGame()
    {
        StartCoroutine(LoadGameRoutine());
    }

    IEnumerator LoadGameRoutine()
    {
        clickSound.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);    
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }

    public void Contact()
    {
        SceneManager.LoadScene("Contact");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
