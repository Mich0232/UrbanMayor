using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

    public GameObject tutorialTap;

	public void Onclick()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        if(tutorialTap != null)
            tutorialTap.GetComponent<DialogTap>().DialogIn();
    }

    public void CloseParent()
    {
        print("tutaj");
        gameObject.transform.parent.gameObject.SetActive(false);

    }
}
