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
    

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }


    private void AddOnClickEffect()  // Add behaviour to button
    {
        Building basicPowerPlant;
        Building basicWaterTower;

        basicPowerPlant = GameController.instance.buildPowerPlant.GetComponent<Building>();          
        basicWaterTower = GameController.instance.buildWaterTower.GetComponent<Building>();

		resourceButton.onClick.AddListener(() => basicWaterTower.Interact());
        resourceButton.onClick.AddListener(() => basicPowerPlant.Interact());
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

    // LVL progress

    public void UpdatedXPBar(float fill)
    {
        xpBar.fillAmount = fill;
    }

    public void UpdateLvlDisplay(int currentLVL)
    {
        lvlDisplay.text = currentLVL.ToString();
    }

}
