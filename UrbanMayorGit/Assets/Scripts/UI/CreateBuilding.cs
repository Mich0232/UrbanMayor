using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBuilding : MonoBehaviour {

    public GameObject prefab;
    GameObject pointsMap;
    private bool follow;
    private GameObject building;
    Vector3 pos;
    public LayerMask points;
    public GameObject panelToClose;
    public GameObject water, power, tutorialTap;
    public bool presentationDone = false;


    void Start()
    {
        if(prefab.GetComponent<Building>().type!=BuildingType.Decoration)
            pointsMap = GameObject.Find("PointsMap");
        else
            pointsMap = GameObject.Find("AccessoriesMap");
        tutorialTap = GameObject.Find("TutorialTap");
        GetComponentInChildren<Text>().text = prefab.GetComponent<Building>().cost.ToString();

    }


	public void CreateBuildingOnClick()
    {
        building = Instantiate(prefab);
            
        building.GetComponent<SpriteRenderer>().sortingOrder=2;
        follow = true;
        panelToClose.transform.localScale = new Vector3(0, 0, panelToClose.transform.localScale.z);

		foreach (GameObject icon in GameObject.FindGameObjectsWithTag("icons"))
		{
			icon.GetComponent<Image>().color = Color.white;
		}
    }

    void Update()
    {
        if (follow)
        {
            ShowDots();
			FollowMouse();
        }

        if (Input.GetMouseButtonDown(0))
            if (follow)
                Snap();
    }

    IEnumerator PopDown()
    {
        Vector2 scale = panelToClose.transform.localScale;
		for (float i = 1; i >= 0; i -= Time.deltaTime)
		{
			panelToClose.transform.localScale = new Vector3(i, i, panelToClose.transform.localScale.z);
			yield return null;
		}

	}

    public void FollowMouse()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0);
        building.transform.position = pos;
	}

    public void Snap()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 100f,points);
        bool build = false;

        if (prefab.GetComponent<Building>().type == BuildingType.Decoration)
        {
            if (hit.collider.GetComponent<Point>().type == PointType.Decoration)
                build = true;
        }
        else {
            if (!hit.collider.GetComponent<Point>().type.Equals(PointType.Decoration)) // czy kafelek w ktory trafilismy jest kafelkiem dekoracyjnym
				build = true;
        }

        if (build)
		{
            HideDots();
			Point point = hit.collider.gameObject.GetComponent<Point>();
            Building buildingScript = building.GetComponent<Building>();
            if (point == null)
                return;

            building.transform.SetParent(point.transform);

			follow = false;
			building.transform.position = hit.transform.position;
			building.transform.localScale = new Vector3(2, 2, 1);
            point.Construct(buildingScript);

            // Build Cost

            int currentMoney = PlayerPrefs.GetInt("Money");
            int buildCost = prefab.GetComponent<Building>().cost;

            if (buildCost > currentMoney)
                return;

            PlayerPrefs.SetInt("Money", currentMoney - buildCost);
            UIController.instance.UpdateResources();

            // usuwanie z menu podstawowych budynkow

            if (building.GetComponent<Building>().type == BuildingType.PowerPlant)
            {
                GameController.instance.buildPowerPlant = building.gameObject;   
                //tutorialTap.GetComponent<DialogTap>().DialogIn();
            }               
			else if (building.GetComponent<Building>().type == BuildingType.WaterTower)
            {
                GameController.instance.buildWaterTower = building.gameObject;
                //tutorialTap.GetComponent<DialogTap>().DialogIn();
            }
            else if (building.GetComponent<Building>().type == BuildingType.House)
			{
				//tutorialTap.GetComponent<DialogTap>().DialogIn();
			}
			else if (building.GetComponent<Building>().type == BuildingType.Cinema)
			{
				//tutorialTap.GetComponent<DialogTap>().DialogIn();
			}
                
            if (GameController.instance.BasicBuildingsReady)
            {

                UIController.instance.DisableBasicBuildingsInStore();
            }
                

		}

		if (water != null && building.GetComponent<Building>().type == BuildingType.WaterTower)
        {
            gameObject.SetActive(false);

        }
		else if (power != null && building.GetComponent<Building>().type == BuildingType.PowerPlant)
			gameObject.SetActive(false);
        
        //UIController.instance.FocusOnClickPanel();
    }

    public void ShowDots()
    {
        foreach(Transform point in pointsMap.transform)
        {
            if (point.GetComponent<Point>().IsEmpty)
                point.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
	public void HideDots()
	{
		foreach (Transform point in pointsMap.transform)
		{
            point.GetComponent<SpriteRenderer>().enabled = false;
		}
	}


}
