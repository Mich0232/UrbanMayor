using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour {
    
    public GameObject panel;
    private bool setActive = true;
	public void Open()
    {

        if (panel.activeInHierarchy) setActive = false;
        else setActive = true;
        foreach(Transform child in panel.transform.parent)
        {
            child.gameObject.SetActive(false);
        }
        //panel.transform.parent.transform.GetChild(i).transform.gameObject.SetActive(false);
        if (setActive || (panel.transform.localScale.x == 0f))
        {
			panel.SetActive(true);
            foreach (GameObject icon in GameObject.FindGameObjectsWithTag("icons"))
            {
				icon.GetComponent<Image>().color = Color.white;
            }
            gameObject.GetComponent<Image>().color = Color.green;
            panel.transform.localScale = new Vector3(1, 1, panel.transform.localScale.z);
        }
        else
			foreach (GameObject icon in GameObject.FindGameObjectsWithTag("icons"))
			{
				icon.GetComponent<Image>().color = Color.white;
			}
    }

}
