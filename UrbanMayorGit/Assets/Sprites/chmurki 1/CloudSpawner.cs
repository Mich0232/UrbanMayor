using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public List<GameObject> clouds = new List<GameObject>();
    public float interval;
	// Use this for initialization
	void Start()
    {
        if (clouds.Count > 0 )
            StartCoroutine(SpawnCycle());
    }

    IEnumerator SpawnCycle()
    {
        while (true)
        {
            float temp = Random.Range(5f, interval);
            yield return new WaitForSecondsRealtime(temp);
            Instantiate(clouds[Random.Range(0, clouds.Count)], transform.position, Quaternion.identity, transform);

        }
    }
}
