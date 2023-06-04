using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public GameObject doorTrigger;
    public GameObject keyModel;
    public GameObject keyOnScreen;

    void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        doorTrigger.SetActive(true);
        keyModel.SetActive(false);
        keyOnScreen.SetActive(true);
    }
}
