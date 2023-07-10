using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject deathText;

    void Start()
    {
        GlobalLife.lifeValue -= 1;
        if (GlobalLife.lifeValue == 0)
        {
            StartCoroutine(ResetRoutine());
        }
        else
        {
            StartCoroutine(GameOverRoutine());
        }
    }

    IEnumerator ResetRoutine()
    {
        gameOver.SetActive(true);
        yield return new WaitForSeconds(3);
        gameOver.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator GameOverRoutine()
    {
        deathText.SetActive(true);
        yield return new WaitForSeconds(2);
        deathText.SetActive(false);
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }
}
