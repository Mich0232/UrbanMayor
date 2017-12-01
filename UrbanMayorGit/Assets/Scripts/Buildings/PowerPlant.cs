using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlant : Building
{

	[Header("Effects")]
	public ParticleSystem energyBurst;

	private ParticleSystem energySpawner;

    public override void TapEffect()
    {
        GetComponent<Animator>().SetTrigger("Tap");
        if (energySpawner != null)
            energySpawner.Emit(1);
        GameController.instance.AddEnergy();
        GameController.instance.AddXP(1);
    }

	public override void Interact()
	{
		base.Interact();
        print("Interact Powerplant");
        UIController.instance.OpenPanel(Panel.PowerPlant);
    }

	public override void OnBuild()
	{
		energySpawner = Instantiate(energyBurst, transform.position, Quaternion.identity, transform).GetComponent<ParticleSystem>();
		base.OnBuild();
	}

}