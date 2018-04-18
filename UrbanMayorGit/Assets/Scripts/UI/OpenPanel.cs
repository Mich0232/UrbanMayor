using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour {
    
    public GameObject panel;
    private bool setActive = true;
    private GameObject clickPanel;

    private void Start()
    {
        clickPanel = UIController.instance.GetClickPanel();
    }

    public void Open()
    {
        if (panel.activeInHierarchy) setActive = false;
        else setActive = true;


        foreach(Transform child in panel.transform.parent)
        {
            child.gameObject.SetActive(false);
        }

        if (setActive || (panel.transform.localScale.x == 0f))
        {
            // Wyłacz tapanie i włacz panel

            clickPanel.SetActive(false);

            panel.SetActive(true);
            panel.transform.localScale = new Vector3(1, 1, panel.transform.localScale.z);
        }
        else
        {
            // Przełącz na tapanie
            clickPanel.SetActive(true);
            
        }
            
    }

}
