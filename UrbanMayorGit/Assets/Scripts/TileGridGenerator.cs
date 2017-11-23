using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGridGenerator : MonoBehaviour {

    [Header("Prefabs")]
    public GameObject tileGrid;
    public GameObject emptyTile;

    public GameObject grassTile;
    public GameObject roadTile;

    [Header("Settings")]
    public int size = 8;
    public Vector2 startPos = Vector2.zero;

	// Use this for initialization
	void Start () {
        GenerateTileMap();
	}


    void GenerateTileMap()
    {
        for (int i = (int)startPos.x; i < size; i++)
            for (int j = (int)startPos.y; j < size; j++)
            {
                GameObject newTile = Instantiate(emptyTile, new Vector2(i, j), Quaternion.identity, tileGrid.transform);
                Instantiate(grassTile, newTile.transform);
            }
                

    }

}
