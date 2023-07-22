using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GlobalHealth : MonoBehaviour
{
    public GameObject healthDisplay;
    public GameObject healthSign;
    public GameObject warningSign;
    public GameObject dangerSign;
    public GameObject criticalSign;
    public static int healthValue;
    public int internalHealth;

    void Start()
    {
        healthValue = PlayerPrefs.GetInt("health");
    }

    void Update()
    {
        PlayerPrefs.SetInt("health", GlobalHealth.healthValue);
        if (healthValue <= 0)
        {
            SceneManager.LoadScene(2);
        }
        internalHealth = healthValue;
        healthDisplay.GetComponent<Text>().text = "" + healthValue;

        if(101 > healthValue && healthValue > 74)
        {
            healthSign.SetActive(true);
            warningSign.SetActive(false);
            dangerSign.SetActive(false);
            criticalSign.SetActive(false);
        }
        else if(75 > healthValue && healthValue > 49)
        {
            healthSign.SetActive(false);
            warningSign.SetActive(true);
            dangerSign.SetActive(false);
            criticalSign.SetActive(false);
        }
        else if(50 > healthValue && healthValue > 24)
        {
            healthSign.SetActive(false);
            warningSign.SetActive(false);
            dangerSign.SetActive(true);
            criticalSign.SetActive(false);
        }
        else if(25 > healthValue)
        {
            healthSign.SetActive(false);
            warningSign.SetActive(false);
            dangerSign.SetActive(false);
            criticalSign.SetActive(true);
        }
    }
}
