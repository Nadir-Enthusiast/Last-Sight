using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingSystem : MonoBehaviour
{
    public GameObject tradingPanel;
    public bool isTrading = false;
    
    void Update()
    {
        if(Input.GetKey("t"))
        {
            if(isTrading == false)
            {
                PausingMenu.isPaused = true;
                Time.timeScale = 0f;
                tradingPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                isTrading = true;
            }
            else
            {
                PausingMenu.isPaused = false;
                Time.timeScale = 1f;
                tradingPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                isTrading = false;
            }
        }
    }
}
