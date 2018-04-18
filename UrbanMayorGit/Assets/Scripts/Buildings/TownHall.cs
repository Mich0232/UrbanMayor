using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : Building {


    public override void Interact()
    {
        base.Interact();
        print("Test");
        UIController.instance.OpenPanel(Panel.TownHall);
        UIController.instance.GetClickPanel().SetActive(false);
    }

}
