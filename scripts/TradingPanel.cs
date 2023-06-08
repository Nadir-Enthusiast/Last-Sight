using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingPanel : MonoBehaviour
{
    public AudioSource goldSound;
    public AudioSource rejectingSound;
    public GameObject rejectedTrade;
    public GameObject successfulTrade;

    public void BuyPistolAmmoX10()
    {
        if(GlobalGold.goldValue < 2)
        {
            StartCoroutine(Rejection());
        }
        else
        {
            StartCoroutine(Buying());
            GlobalGold.goldValue -= 2;
            GlobalAmmo.handgunAmmo += 10;
        }
    }

    public void BuyPistolAmmoX100()
    {
        if(GlobalGold.goldValue < 19)
        {
            StartCoroutine(Rejection());
        }
        else
        {
            StartCoroutine(Buying());
            GlobalGold.goldValue -= 19;
            GlobalAmmo.handgunAmmo += 100;
        }
    }

    public void BuyMedicine()
    {
        if(GlobalGold.goldValue < 5)
        {
            StartCoroutine(Rejection());
        }
        else
        {
            StartCoroutine(Buying());
            GlobalGold.goldValue -= 5;
            GlobalHealth.healthValue += 30;
        }
    }

    public void BuyRifle()
    {
        if(GlobalGold.goldValue < 15)
        {
            StartCoroutine(Rejection());
        }
        else
        {
            StartCoroutine(Buying());
            ChangeWeapon.weaponsObtained.Add(2);
            GlobalGold.goldValue -= 15;
            PlayerPrefs.SetString("WeaponsObtained", string.Join( ",", ChangeWeapon.weaponsObtained));
        }
    }

    public void BuyRifleAmmoX10()
    {
        if(GlobalGold.goldValue < 3)
        {
            StartCoroutine(Rejection());
        }
        else
        {
            StartCoroutine(Buying());
            GlobalGold.goldValue -= 3;
            GlobalAmmo.rifleAmmo += 10;
        }
    }

    public void BuyRifleAmmoX100()
    {
        if(GlobalGold.goldValue < 26)
        {
            StartCoroutine(Rejection());
        }
        else
        {
            StartCoroutine(Buying());
            GlobalGold.goldValue -= 26;
            GlobalAmmo.rifleAmmo += 100;
        }
    }

    IEnumerator Rejection()
    {
        Time.timeScale = 1f;
        rejectingSound.Play();
        rejectedTrade.SetActive(true);
        yield return new WaitForSeconds(2);
        rejectedTrade.SetActive(false);
        Time.timeScale = 0f;
    }

    IEnumerator Buying()
    {
        Time.timeScale = 1f;
        goldSound.Play();
        successfulTrade.SetActive(true);
        yield return new WaitForSeconds(2);
        successfulTrade.SetActive(false);
        Time.timeScale = 0f;
    }
}
