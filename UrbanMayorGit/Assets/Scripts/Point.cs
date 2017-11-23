using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

    public int id;
    private Building building;

    void Awake()
    {
        id = gameObject.transform.GetSiblingIndex();
    }

    public Building GetBuilding()
    {
        return building;
    }

    public bool IsEmpty
    {
        get {
            return this.building == null;
        }
    }

    public void Construct(Building newBuilding)
    {
        if (!IsEmpty) return;

        this.building = newBuilding;
        newBuilding.OnBuild();
    }

}
