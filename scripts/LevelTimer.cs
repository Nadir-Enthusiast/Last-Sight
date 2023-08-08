using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public int secondCount = 0;
    public int minuteCount = 0;
    public GameObject timerDisplay;
    public bool addingTime = false;

    void Update()
    {
        if(addingTime == false)
        {
            StartCoroutine(AddSeconds());
        }
    }

    IEnumerator AddSeconds()
    {
        addingTime = true;
        yield return new WaitForSeconds(1);
        secondCount += 1;
        if(secondCount == 60)
        {
            secondCount = 0;
            minuteCount += 1;
        }
        if(secondCount < 10)
        {
            timerDisplay.GetComponent<Text>().text = "" + minuteCount + ":0" + secondCount;
        }
        else
        {
            timerDisplay.GetComponent<Text>().text = "" + minuteCount + ":" + secondCount;
        }
        addingTime = false;
    }
}
