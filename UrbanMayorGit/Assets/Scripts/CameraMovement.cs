using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [Header("Propeties")]
    [Range(0.01f, 1f)]
    public float dragForce = .1f;
    public float dragSpeed = 2;
    public bool inverted = false;
    [HideInInspector]
    public bool dragingObj = false;

    private float maxDrag;
    private float clip = 0.05f;

    private Vector3 dragOrigin;


    private void Start()
    {
        maxDrag = dragSpeed;
        if (inverted)
            dragSpeed *= -1f;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (dragingObj) return;

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);

        if (pos.magnitude > clip)
        {
            dragSpeed = dragSpeed * (pos.magnitude / dragForce);
            dragSpeed = Mathf.Clamp(dragSpeed, clip, maxDrag);
        }
        else
            return;

        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

        if (move.magnitude <= clip)
            return;

        transform.Translate(move, Space.World);

    }

    private void LateUpdate()
    {
        float camX = transform.position.x;
        float camY = transform.position.y;
        camX = Mathf.Clamp(camX, -7.5f, 3.9f);
        camY = Mathf.Clamp(camY, -4.3f, 0);

        transform.position = new Vector3(camX, camY, -10f);

    }
}
