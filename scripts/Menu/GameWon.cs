using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GameComplete());
    }

    IEnumerator GameComplete()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene("Menu");
    }
}
