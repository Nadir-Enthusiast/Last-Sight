using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefDeath : MonoBehaviour
{
    public int thiefHealth = 15;
    public int thiefId;
    public bool thiefDead = false;
    public GameObject thiefBody;

    void DamageEnemy (int damageAmount)
    {
        thiefHealth -= damageAmount;
        Debug.Log("hit");
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("thiefDefeated" + thiefId))
        {
            thiefDead = true;
            thiefBody.SetActive(false);
        }
    }

    void Update()
    {
        if (thiefHealth <= 0 && thiefDead == false)
        {
            thiefDead = true;
            thiefBody.SetActive(false);

            PlayerPrefs.SetInt("thiefDefeated" + thiefId, 0);
        }
    }
}
