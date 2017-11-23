using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinema : Building {

    public override void Interact()
    {
        base.Interact();
        GameObject.Find("Kino").transform.GetChild(0).gameObject.SetActive(true);

    }

}
