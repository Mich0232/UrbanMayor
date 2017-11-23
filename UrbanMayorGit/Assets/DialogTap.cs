using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTap : MonoBehaviour {

    public GameObject dialogBar, girl;
    int[] breaks = new int[]{2,3,4,5,9,10};
    bool firstAchievement = false;

    void Update()
    {
        if (!firstAchievement && ( PlayerPrefs.GetInt("Energy") >= 20 && PlayerPrefs.GetInt("Water") >= 20))
        {
            DialogIn();
            firstAchievement = true;
        }    
    }

	public void Tap()
    {
        for (int i = 0; i < breaks.Length; i++)
            if(breaks[i]==GameObject.Find("Dialog").GetComponent<Dialog>().i)
            {
                DialogOut();
				StartCoroutine(Wait());
                break;
            }
        if (GameObject.Find("Dialog").GetComponent<Dialog>().i > 10)
            DialogOut();
		GameObject.Find("Dialog").GetComponent<Dialog>().OnClick();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
		//GameObject.Find("Dialog").GetComponent<Dialog>().OnClick();
    }

	IEnumerator Wait2()
	{
		yield return new WaitForSeconds(0.5f);
		girl.GetComponent<Animator>().SetBool("MoveOut", false);
	}

	IEnumerator Wait3()
	{
		yield return new WaitForSeconds(0.5f);
		girl.GetComponent<Animator>().SetBool("MoveIn", false);
	}

    public void DialogOut()
    {
        dialogBar.GetComponent<Animator>().SetBool("PopDown",true);
		girl.GetComponent<Animator>().SetBool("MoveOut", true);
		GetComponent<Image>().enabled = false;
        StartCoroutine(Wait2());
    }

    public void DialogIn()
    {
		dialogBar.GetComponent<Animator>().SetBool("PopDown", false);
		girl.GetComponent<Animator>().SetBool("MoveIn", true);
		GetComponent<Image>().enabled = true;
		StartCoroutine(Wait3());
    }
}
