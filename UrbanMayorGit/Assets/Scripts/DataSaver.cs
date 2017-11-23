using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour {

    public static DataSaver instance;
    public GameObject pointsMap;
    public List<GameObject> buildings;

	private void Awake()
	{
        PlayerPrefs.DeleteAll();
		if (instance != null)
			return;
		instance = this;
	}

    void Start()
    {
        ReadMap();
    }

    public void ReadMap()
    {
        GameObject temp;
		foreach (Transform point in pointsMap.transform)
		{
            if(PlayerPrefs.HasKey("Point"+point.GetComponent<Point>().id.ToString()))
            {
                print("Wczytuje na mape " + (BuildingType)PlayerPrefs.GetInt("Point" + point.GetComponent<Point>().id) + " na " + point.name);
                temp = Instantiate(buildings[PlayerPrefs.GetInt("Point" + point.GetComponent<Point>().id)]);
                point.GetComponent<Point>().Construct(temp.GetComponent<Building>());
                temp.transform.SetParent(point);
                temp.transform.localPosition = new Vector3(0, 0, temp.transform.localPosition.z);
            }

	    }
    }

	public void SaveMap()
    {
        foreach(Transform point in pointsMap.transform)
        {
            if(!point.GetComponent<Point>().IsEmpty)
            {
                //print("Zapisuje: " + point.GetComponent<Point>().GetBuilding().type + " do "+"Point" + point.GetComponent<Point>().id);
				PlayerPrefs.SetInt("Point" + point.GetComponent<Point>().id, (int)point.GetComponent<Point>().GetBuilding().type);
            }
        }
    }
}
