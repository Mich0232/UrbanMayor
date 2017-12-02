using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour {

    public static UIController instance;

    [Header("Resources Display")]
    public Text waterDisplay;
    public Text energyDisplay;
    public Text populationDisplay;
    public Text moneyDisplay;

    [Header("Tap Buttons")]
    public Button resourceButton;

    [Header("LVL Progress")]
    public Image xpBar;
    public Text lvlDisplay;

    [Header("Basic Buildings Store")]
    public GameObject waterTowerStore;
    public GameObject powerPlantStore;

    bool alreadyDisabled = false;
    public GameObject buildingObject;
    public GameObject buildingsPanel;

    [Header("Other")]
    public GameObject clickPanel;
    public GameObject centerPanel;
    

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }


    private void AddOnClickEffect()  // Add behaviour to button
    {
        resourceButton.gameObject.SetActive(true);
        resourceButton.gameObject.transform.parent.gameObject.SetActive(true);

        Building basicPowerPlant;
        Building basicWaterTower;

        basicPowerPlant = GameController.instance.buildPowerPlant.GetComponent<Building>();          
        basicWaterTower = GameController.instance.buildWaterTower.GetComponent<Building>();

		resourceButton.onClick.AddListener(() => basicWaterTower.TapEffect());
        resourceButton.onClick.AddListener(() => basicPowerPlant.TapEffect());
    }

    public void UpdateResources() // Refresh gui displays from playerPrefs
    {
        waterDisplay.text = PlayerPrefs.GetInt("Water").ToString();
        energyDisplay.text = PlayerPrefs.GetInt("Energy").ToString();
        populationDisplay.text = PlayerPrefs.GetInt("Population").ToString();
        moneyDisplay.text = PlayerPrefs.GetInt("Money").ToString();

    }

    public void DisableBasicBuildingsInStore() // Disables buying waterTower & PowerPlant
    {
        if (alreadyDisabled)
            return;

        if(powerPlantStore != null && waterTowerStore != null)
        {
            buildingObject.GetComponent<OpenPanel>().panel = buildingsPanel;
			Destroy(waterTowerStore);
			Destroy(powerPlantStore);

			AddOnClickEffect();
			alreadyDisabled = true;
        }

    }

    public void FocusOnClickPanel()
    {

        foreach (Transform child in clickPanel.transform.parent)
        {
            child.gameObject.SetActive(false);
        }
        clickPanel.SetActive(true);

    }

    // LVL progress

    public void UpdatedXPBar(float fill)
    {
        xpBar.fillAmount = fill;
    }

    public void UpdateLvlDisplay(int currentLVL)
    {
        lvlDisplay.text = currentLVL.ToString();
    }

    public GameObject GetClickPanel()
    {
        return clickPanel;
    }

    public void OpenPanel(Panel buildingPanel)
    {
        //GameObject centerPanel = GameObject.FindGameObjectWithTag("CenterPanel");
        if (centerPanel == null)
            return;

        foreach(Transform child in centerPanel.transform)
        {
            child.gameObject.SetActive(false);

            if (buildingPanel != Panel.CloseAll && child.CompareTag(buildingPanel.ToString()))
                child.gameObject.SetActive(true);
            
        }

    }

}

public enum Panel
{
    Cinema,
    TownHall,
    TaxOffice,
    Jeweller,
    Hotel,
    Warehouse,
    WaterTower,
    PowerPlant,
    CloseAll
}
