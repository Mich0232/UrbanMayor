using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTower : Building
{

	[Header("Effects")]
	public ParticleSystem waterBurst;
	private ParticleSystem waterSpawner;

	public override void Interact()
	{
		base.Interact();
		GetComponent<Animator>().SetTrigger("Tap");
		if (waterSpawner != null)
			waterSpawner.Emit(1);
		GameController.instance.AddWater();
		GameController.instance.AddXP(1);
	}

	public override void OnBuild()
	{
		waterSpawner = Instantiate(waterBurst, transform.position, Quaternion.identity, transform).GetComponent<ParticleSystem>();
		base.OnBuild();
	}


}