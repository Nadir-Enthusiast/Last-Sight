using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class WinCube : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject finishCollider;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FinalLevel());
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        finishCollider.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator FinalLevel()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);

        PlayerPrefs.SetInt("gold", GlobalGold.goldValue);
        PlayerPrefs.SetInt("ammo", GlobalAmmo.handgunAmmo);

        PlayerPrefs.SetString("WeaponsObtained", string.Join( ",", ChangeWeapon.weaponsObtained));
        SceneManager.LoadScene("GameWon");
    }
}
