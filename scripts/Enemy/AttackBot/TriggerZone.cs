using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public string hitTag;
    public GameObject light;
    public AudioSource shotSound;
    public Transform player;
    public Transform enemy;
    public GameObject enemyObject;
    public bool isIdle = true;
    public bool isNotShooting = true;
    public int damageIntensity = 15;

    void Start()
    {
        enemyObject.GetComponent<Animator>().enabled = false;
    }

    void Update()
    {
        if(isIdle && isNotShooting)
        {
            if(enemyObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Finish"))
            {
                enemyObject.GetComponent<Animator>().Play("AttackBotMove");
                isIdle = false;
                StartCoroutine(Animation());
                enemyObject.GetComponent<Animator>().enabled = true;
            }
            else
            {
                enemyObject.GetComponent<Animator>().enabled = true;
            }
        }
        transform.LookAt(player);
        hitTag = "None";
        RaycastHit Hit;
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Hit, 32))
        {
            hitTag = Hit.transform.tag;
        }
        if (hitTag == "Player" && isNotShooting)
        {
            isNotShooting = false;
            enemyObject.GetComponent<Animator>().enabled = false;
            enemy.transform.LookAt(player);
            StartCoroutine(Shoot());
        }
        else if(isNotShooting)
        {
            enemyObject.GetComponent<Animator>().enabled = true;
        }
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(12);
        Debug.Log("finished");
        isIdle = true;
    }

    IEnumerator Shoot()
    {
        light.SetActive(true);
        shotSound.Play();
        yield return new WaitForSeconds(0.25f);
        light.SetActive(false);
        GlobalHealth.healthValue -= damageIntensity;
        yield return new WaitForSeconds(1);
        isNotShooting = true;
    }
}
