using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewellery : Building {


    public GameObject panel;

    private void Awake()
    {
        panel = GameObject.FindWithTag("jub");
    }

    public override void Interact()
    {
        base.Interact();
        UIController.instance.OpenPanel(Panel.Jeweller);
        UIController.instance.GetClickPanel().SetActive(false);

    }
}
