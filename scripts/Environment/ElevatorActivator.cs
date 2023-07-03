using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivator : MonoBehaviour
{
    public GameObject elevatorTip;
    public GameObject elevatorScript;
    
    void OnTriggerEnter(Collider other) {
        elevatorScript.SetActive(true);
        elevatorTip.SetActive(true);
    }

    void OnTriggerExit(Collider other) {
        elevatorScript.SetActive(false);
        elevatorTip.SetActive(false);
    }
}
