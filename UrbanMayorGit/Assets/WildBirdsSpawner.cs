using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBirdsSpawner : MonoBehaviour {

    public GameObject bird;

	// Use this for initialization
	void Start () {
        if (bird != null)
            StartCoroutine(SpawnCycle());
	}
	
	IEnumerator SpawnCycle()
    {
        while(true)
        {
            float interval = Random.Range(10f, 20f);
            yield return new WaitForSecondsRealtime(interval);
            Instantiate(bird, transform.position, Quaternion.identity, transform);
            
        }
    }
}
