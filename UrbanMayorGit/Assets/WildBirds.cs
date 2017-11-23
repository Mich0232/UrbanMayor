using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBirds : MonoBehaviour {

    Vector3 destination;
    public float movespeed;

    private void Start()
    {
        destination = new Vector3(transform.position.x - 24f, transform.position.y + 48f, 0);
        Destroy(gameObject, 20f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * movespeed);
    }
}
