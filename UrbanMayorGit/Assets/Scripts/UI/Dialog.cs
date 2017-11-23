using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

    public GameObject panelToHide;
	public List<string> teksty;
	Text text;
	public int i = 1;
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            OnClick();
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            Decrement();
    }

    // Update is called once per frame
    public void OnClick () {
		text.text = teksty[i];
        if(i<teksty.Count)
		    i++;
        else
            panelToHide.SetActive(false);
        
	}

    public void Decrement()
	{
        if(i>0)
		    i--;
		text.text = teksty[i];
    }
}
