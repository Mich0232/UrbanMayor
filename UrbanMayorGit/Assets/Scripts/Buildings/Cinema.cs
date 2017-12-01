using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinema : Building {

    public override void Interact()
    {
        base.Interact();
        UIController.instance.OpenPanel(Panel.Cinema);
        UIController.instance.GetClickPanel().SetActive(false);
    }

}
