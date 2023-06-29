using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealWithMedicine : MonoBehaviour
{
    public AudioSource healSound;

    void OnTriggerEnter(Collider other)
    {
        if(GlobalHealth.healthValue >= 70)
        {
            GlobalHealth.healthValue = 100;
        }
        else
        {
            GlobalHealth.healthValue += 30;
        }
        healSound.Play();
        GetComponent<BoxCollider>().enabled = false;
        this.gameObject.SetActive(false);
    }
}
