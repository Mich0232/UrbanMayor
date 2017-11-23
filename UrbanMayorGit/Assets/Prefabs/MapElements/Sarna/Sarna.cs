using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Sarna : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Movement());
	}
	
	IEnumerator Movement()
    {
        while(true)
        {
            float interval = Random.Range(3f, 5f);        
            yield return new WaitForSecondsRealtime(interval);
            GetComponent<Animator>().SetTrigger("Roar");
        }
    }
}
