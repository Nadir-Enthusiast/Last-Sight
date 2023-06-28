using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCollect : MonoBehaviour
{
    public GameObject goldModel;
    public GameObject pickText;
    public GameObject light;
    public AudioSource goldPicking;
    public int goldId;
    public int goldAmount = 1;
    public bool isCollected = false;

    void Start()
    {
        if(PlayerPrefs.HasKey("goldCollected"+goldId))
        {
            isCollected = true;
            goldModel.SetActive(false);
            light.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!isCollected)
        {
            GlobalGold.goldValue += goldAmount;
            goldModel.SetActive(false);
            goldPicking.Play();
            GetComponent<BoxCollider>().enabled = false;
            pickText.SetActive(false);
            pickText.GetComponent<Text>().text = "Gold picked up";
            pickText.SetActive(true);
            light.SetActive(false);

            PlayerPrefs.SetInt("goldCollected" + goldId, 0);
        }
    }
}
