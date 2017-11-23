using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour {

    public GameObject pobierz;
    public GameObject missionPanel;
    public GameObject loading;
    public AudioSource audioS;
    public AudioSource audioEFX;

    private void Awake()
    {
        Time.timeScale = 0f;
    }



	public void OnClickOtworz()
	{
        /*
        Time.timeScale = 1f;
        missionPanel.SetActive(true);
        loading.SetActive(true);
        Destroy(gameObject);
        */
        GetComponent<Image>().enabled = false;
        pobierz.SetActive(false);
        StartCoroutine(Wait());
	}

    IEnumerator Wait()
    {
        loading.SetActive(true);
        audioS.Play();
        yield return new WaitForSecondsRealtime(2f);
        audioEFX.Play();
		Time.timeScale = 1f;
		missionPanel.SetActive(true);
        Destroy(loading);
        Destroy(gameObject);

    }
}
