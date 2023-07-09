using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SaveProgress : MonoBehaviour
{
    public GameObject thePlayer;

    // Start After Completing previous level or load from menu
    void Start()
    {
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
        GlobalAmmo.handgunAmmo = PlayerPrefs.GetInt("ammo");
        GlobalGold.goldValue = PlayerPrefs.GetInt("gold");
        GlobalLevel.currentLevel = PlayerPrefs.GetInt("currentLevel");
    }

}
