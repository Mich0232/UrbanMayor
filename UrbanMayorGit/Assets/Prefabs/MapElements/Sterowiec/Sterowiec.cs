using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sterowiec : MonoBehaviour {

    Vector3 destination;
    public float movespeed;

    public GameObject adPanel;

    private void Start()
    {
        destination = new Vector3(transform.position.x + 36f, transform.position.y + 36f, 0);
        Destroy(gameObject, 40f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * movespeed);
    }

    private void OnMouseDown()
    {
        if(adPanel != null)
            adPanel.SetActive(true);
        Destroy(gameObject, 1f);
    }
}
