using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building {

    public int waterUsage = 1;
    public int energyUsage = 1;

    public int residents = 1;
    int maxResidents = 3;

    public override void OnBuild()
    {
        base.OnBuild();
        GameController.instance.AddPopulation(residents);
        GameController.instance.AddUsage(waterUsage, energyUsage);
    }

    public override void Upgrade()
    {
        base.Upgrade();
        this.lvl++;
        this.maxResidents += 2;
    }

    public bool AddResident()
    {
        if(this.residents < maxResidents)
        {
            residents++;
            waterUsage++;
            energyUsage++;
            GameController.instance.AddUsage(1, 1);
            return true;
        }
        return false;
    }
}
