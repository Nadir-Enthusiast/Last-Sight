using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingAI : MonoBehaviour
{
    public GameObject tradingText;
    public GameObject tradingScript;

    void OnTriggerEnter(Collider other) {
        tradingText.SetActive(true);
        tradingScript.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        tradingText.SetActive(false);
        tradingScript.SetActive(false);
    }
}
