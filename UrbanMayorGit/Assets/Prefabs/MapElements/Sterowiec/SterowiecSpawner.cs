using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SterowiecSpawner : MonoBehaviour {

    public GameObject sterowiec;

    bool spawned = false;

    private void Update()
    {
        if(!spawned)
            if(Input.GetKeyDown(KeyCode.Alpha9))
            {
                Instantiate(sterowiec, transform.position, Quaternion.identity, transform.parent);
                spawned = true;
            }
    }
}
