using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject theGun;
    public GameObject flash;
    public AudioSource fireSound;
    public AudioSource emptySound;
    public bool isFiring = false;
    public float targetDistance;
    public int damageAmount;

    void Start()
    {
        // GlobalAmmo.handgunAmmo = 100;
        damageAmount = 5;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !PausingMenu.isPaused)
        {
            if (GlobalAmmo.handgunAmmo < 1)
            {
                emptySound.Play();
            }
            else if (isFiring == false)
            {
                StartCoroutine(FiringGun());
            }
        }
    }

    IEnumerator FiringGun()
    {
        RaycastHit theShot;
        isFiring = true;
        GlobalAmmo.handgunAmmo -= 1;
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out theShot, 100f))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            targetDistance = theShot.distance;
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green);
            theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
        }
        theGun.GetComponent<Animator>().Play("FireTheGun");
        flash.SetActive(true);
        fireSound.Play();
        yield return new WaitForSeconds(0.05f);
        flash.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}
