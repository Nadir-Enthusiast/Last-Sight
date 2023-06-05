using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public string hitTag;
    public bool lookingAtPlayer = false;
    public GameObject enemyTrigger;
    public GameObject attackTrigger;
    public AudioSource attackSound;
    public bool isAttacking = false;
    public float attackRate = 1f;
    public int genHurt;
    public int damage = 5;
    public int reach = 16;
    public AudioSource[] hurtSounds;
    public GameObject hurtFlash;
    
    void Update()
    {
        hitTag = "None";
        RaycastHit Hit;
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Hit, reach))
        {
            hitTag = Hit.transform.tag;
        }
        if (hitTag == "Player" && isAttacking == false)
        {
            StartCoroutine(EnemyAttack());
        }
        if ( hitTag != "Player")
        {
            enemyTrigger.SetActive(false);
            lookingAtPlayer = false;
        }
        
    }

    IEnumerator EnemyAttack()
    {
        isAttacking = true;
        lookingAtPlayer = true;
        enemyTrigger.SetActive(false);
        attackTrigger.SetActive(true);
        attackSound.Play();
        GlobalHealth.healthValue -= damage;
        yield return new WaitForSeconds(0.4f);
        genHurt = Random.Range(0, 3);
        hurtSounds[genHurt].Play();
        hurtFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackTrigger.SetActive(false);
        enemyTrigger.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hurtFlash.SetActive(false);
        yield return new WaitForSeconds(attackRate-0.5f);
        isAttacking = false;
    }
}
