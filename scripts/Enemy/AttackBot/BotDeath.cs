using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotDeath : MonoBehaviour
{
    public int bmuHealth = 50;
    public int bmuId;
    public bool bmuDead = false;
    public GameObject bmuBody;
    public GameObject bmuAI;
    public GameObject hurtFlash;

    void DamageEnemy (int damageAmount)
    {
        // Debug.Log("Damage!");
        bmuHealth -= damageAmount;
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("bmuDefeated" + bmuId))
        {
            bmuDead = true;
            bmuBody.SetActive(false);
            bmuAI.SetActive(false);
        }
    }

    void Update()
    {
        if (bmuHealth <= 0 && bmuDead == false)
        {
            bmuDead = true;
            bmuBody.SetActive(false);
            bmuAI.SetActive(false);
            hurtFlash.SetActive(false);

            PlayerPrefs.SetInt("bmuDefeated" + bmuId, 0);
        }
    }
}
