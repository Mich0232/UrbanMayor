using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    Vector3 destination;
    public float movespeed;

    private void Start()
    {
        destination = new Vector3(transform.position.x - 48f, transform.position.y + 48f, 0);
        Destroy(gameObject, 20f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * movespeed);
    }
}
