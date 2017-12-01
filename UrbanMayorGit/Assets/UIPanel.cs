using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour {

	public void ClosePanel()
    {
        UIController.instance.OpenPanel(Panel.CloseAll);
    }
}
