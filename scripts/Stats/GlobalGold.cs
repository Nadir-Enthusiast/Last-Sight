using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalGold : MonoBehaviour
{
    public GameObject goldDisplay;
    public static int goldValue;
    public int internalGold;
    
    void Start()
    {
        goldValue = PlayerPrefs.GetInt("gold");
    }

    void Update()
    {
        internalGold = goldValue;
        goldDisplay.GetComponent<Text>().text = "" + goldValue;
        PlayerPrefs.SetInt("gold", GlobalGold.goldValue);
    }
}
