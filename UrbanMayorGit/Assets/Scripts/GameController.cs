using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;

    private int energy = 0;
    private int energyMul = 1;
    private int energyTotalUsage = 0;

    private int water = 0;
    private int waterMul = 1;
    private int waterTotalUsage = 0;
    

    private int population = 0;
    private int money = 300;
    private int moneyMul = 1;

    private int tourists = 0;
    private int gems = 0;

    // XP system
    private int currentLvl = 1;
    private int currentXP = 0;
    private int neededXP = 100;

    bool gameover = false;


    public GameObject buildWaterTower;
    public GameObject buildPowerPlant;

	public GameObject pulpit;
	public GameObject ambience;

    public bool BasicBuildingsReady
    {
        get
        {
            if (buildWaterTower != null && buildPowerPlant != null) return true;
            return false;
        }
    }

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
		PlayerPrefs.DeleteAll();
        InitPlayerPrefs();
        StartCoroutine(ResourceUsage());
    }

	private void Update()
	{
		KeyManager();
	}

	void KeyManager()
	{
		if (Input.GetKey(KeyCode.Alpha1))
		{
			pulpit.SetActive(true);
			ambience.SetActive(false);
		}
	}

    void InitPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("Energy"))
            PlayerPrefs.SetInt("Energy", energy);

        if (!PlayerPrefs.HasKey("Water"))
            PlayerPrefs.SetInt("Water", water);

        if (!PlayerPrefs.HasKey("Population"))
            PlayerPrefs.SetInt("Population", population);

        if (!PlayerPrefs.HasKey("Money"))
            PlayerPrefs.SetInt("Money", money);

		if (!PlayerPrefs.HasKey("Gems"))
			PlayerPrefs.SetInt("Gems", gems);

        UIController.instance.UpdateResources();

    }

    public void AddWater() { // Clip to UI Button
        this.water += 1 * waterMul;
        PlayerPrefs.SetInt("Water", (int)water);
        UIController.instance.UpdateResources();
    }

    public void AddEnergy() { // Clip to UI Button
        this.energy += 1 * energyMul;
        PlayerPrefs.SetInt("Energy", energy);
        UIController.instance.UpdateResources();
    }

    public void AddPopulation(int value) { // On House build
        if (value < 0) return;
        this.population += value;
        PlayerPrefs.SetInt("Population", population);
        UIController.instance.UpdateResources();
    }


    public void AddUsage(int waterUsage, int energyUsage)
    {
        this.waterTotalUsage += waterUsage;
        this.energyTotalUsage += energyUsage;
    }

    public void AddXP(int value)
    {
        this.currentXP += value;
        float fill_amount;
        if(this.currentXP >= this.neededXP)
        {
            currentLvl++;
            currentXP -= neededXP;
			neededXP += 20;

            //fill_amount = ((float)currentXP / (float)neededXP);
            fill_amount = Mathf.Clamp01(((float)currentXP / (float)neededXP));
            UIController.instance.UpdatedXPBar(fill_amount);
            UIController.instance.UpdateLvlDisplay(currentLvl);
        }
        //fill_amount = (currentXP / neededXP);
        fill_amount = Mathf.Clamp01(((float)currentXP / (float)neededXP));
        UIController.instance.UpdatedXPBar(fill_amount);
    }

	public void UseOffer()
	{
		int gemstmp = PlayerPrefs.GetInt("Gems");
		PlayerPrefs.SetInt("Gems", gemstmp + 50);


		int additionalMoney = PlayerPrefs.GetInt("Money") + 10000;
		PlayerPrefs.SetInt("Money", additionalMoney);
		energy += 500;
		water += 500;
	}


    IEnumerator ResourceUsage() // On Main loop
    {
        while(!gameover)
        {
            bool missingResource = false;

            if(water <= 0 || energy <= 0)
            {
                missingResource = true;
            }
            else
            {
                // Water usage
                water -= waterTotalUsage;
                if (water <= 0)
                    water = 0;

                // Energy
                energy -= energyTotalUsage;

                if (energy <= 0)
                    energy = 0;

            }


            if(!missingResource)
            {
                // Add Money
                int currMoney = PlayerPrefs.GetInt("Money");
                currMoney += population * (1 * moneyMul);
                PlayerPrefs.SetInt("Money", currMoney);
            }

            PlayerPrefs.SetInt("Energy", energy);
            PlayerPrefs.SetInt("Water", (int)water);

            UIController.instance.UpdateResources();
            yield return new WaitForSecondsRealtime(1f);
        }
    }


}

