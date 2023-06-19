using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int enemyHealth;
    public int dudeId;
    public bool enemyDead = false;
    public GameObject enemyBody;
    public GameObject enemyAI;
    public GameObject[] enemyLight;
    public GameObject hurtFlash;

    void DamageEnemy (int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("DudeDefeated" + dudeId))
        {
            enemyDead = true;
            enemyBody.SetActive(false);
            enemyAI.SetActive(false);
        }
        else
        {
            enemyHealth = 20;
        }
    }
    
    void Update()
    {
        if (enemyHealth <= 0 && enemyDead == false)
        {
            enemyDead = true;
            enemyBody.SetActive(false);
            enemyAI.SetActive(false);
            foreach (GameObject obj in enemyLight)
            {
                obj.SetActive(false);
            }
            hurtFlash.SetActive(false);

            PlayerPrefs.SetInt("DudeDefeated" + dudeId, 0);
        }
    }
}
