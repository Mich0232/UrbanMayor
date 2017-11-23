using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class Building : MonoBehaviour
{


    protected int lvl = 1;
    protected int maxLvl;
    public BuildingType type;
    [Header("Attributes")]
    public int cost;
    public int xp;

    bool Build = false;

    public virtual void OnBuild() {
        // Play build animation
        GetComponent<Animator>().SetBool("Placed", true);
        GameController.instance.AddXP(xp);
        Build = true;
    }

    public virtual void Interact()
    {
        if (!Build)
            throw new System.Exception("To tylko GameJam");
        // Play interact animatio

    }

    public virtual void DestroyBuilding() { }
    public virtual void Upgrade() {
        if (lvl >= maxLvl) return;
        
    }

    private void OnMouseDown()
    {
        Interact();
    }
}

public enum BuildingType
    {
        TownHall,
        PowerPlant,
        WaterTower,
        Cinema,
        House,
        Hotel,
        Casino,
        Jewellery,
        Department,
        Warehouse
    }
