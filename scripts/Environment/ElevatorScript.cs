using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public GameObject theElevator;
    public bool isOn = true;

    void Update()
    {
        if(Input.GetKey("e") && isOn)
        {
            theElevator.GetComponent<Animator>().enabled = true;
            isOn = false;
        }
        else if(Input.GetKey("e") && !isOn)
        {
            theElevator.GetComponent<Animator>().enabled = false;
            isOn = true;
        }
    }
}
