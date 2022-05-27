using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeController : MonoBehaviour
{
    public ManageCatPosition catPosition;
    public ResourcesController resources;
    public UpgradesHandeling upgrades;
    public ManageStoring storing;
    public SavingManager saver;
    public float upgradeCoins=1;
    public float upgradeFurniture=1;
    public float upgradePopularity=1;
    public float totalPopularity = 0.0f;
    public float furniturePopularity = 0.0f;
    public float totalCoins = 0.0f;
    public float heightOutofFurniture = 0.0f;
    public GameObject[] Toy;
    public int actualToy;
    public GameObject[] Chair;
    public int actualChair;
    public GameObject[] Box;
    public int actualBox;
    public GameObject[] Plant;
    public int actualPlant;
    public GameObject[] dupCats;
    public GameObject[] catSpaces;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePopularityAndCoins();
        
    }
    void UpdatePopularityAndCoins()
    {
        UpdateFurniturePopularity();
        totalPopularity = 0.0f;
        totalCoins = 0.0f;
        if (catPosition.catCoins1 != null)
        {
            totalPopularity+= catPosition.catCoins1.GetComponent<CatCaracteristics>().Popularity * upgradePopularity;
            totalCoins += catPosition.catCoins1.GetComponent<CatCaracteristics>().CoinsPerSecond * upgradeCoins;
        }
        if (catPosition.catCoins2 != null)
        {
            totalPopularity += catPosition.catCoins2.GetComponent<CatCaracteristics>().Popularity * upgradePopularity;
            totalCoins += catPosition.catCoins2.GetComponent<CatCaracteristics>().CoinsPerSecond * upgradeCoins;
        }
        if (catPosition.catCoins3 != null)
        {
            totalPopularity += catPosition.catCoins3.GetComponent<CatCaracteristics>().Popularity * upgradePopularity;
            totalCoins += catPosition.catCoins3.GetComponent<CatCaracteristics>().CoinsPerSecond * upgradeCoins;
        }
        totalPopularity += furniturePopularity * upgradeFurniture;
    }
    void UpdateFurniturePopularity()
    {
        furniturePopularity = 0.0f;
        if (Chair[actualChair].activeSelf)
        {
            furniturePopularity+=Chair[actualChair].GetComponent<FurnitureCaracteristics>().Popularity;
        }
        if (Toy[actualToy].activeSelf)
        {
            furniturePopularity+= Toy[actualToy].GetComponent<FurnitureCaracteristics>().Popularity;
        }
        if (Plant[actualPlant].activeSelf)
        {
            furniturePopularity+= Plant[actualPlant].GetComponent<FurnitureCaracteristics>().Popularity;
        }
        if (Box[actualBox].activeSelf)
        {
            furniturePopularity+= Box[actualBox].GetComponent<FurnitureCaracteristics>().Popularity;
        }
    }
    public void ChangeChair(int numChair)
    {
        if (Chair[actualChair].GetComponent<FurnitureCaracteristics>().Popularity < Chair[numChair].GetComponent<FurnitureCaracteristics>().Popularity)
        {
            Chair[actualChair].GetComponent<FurnitureCaracteristics>().Popularity = Chair[numChair].GetComponent<FurnitureCaracteristics>().Popularity;
        }
        Chair[actualChair].SetActive(false);
        actualChair = numChair;
        Chair[actualChair].SetActive(true);

        saver.SaveData();
    }
    public void ChangeToy(int numToy)
    {
        if (Chair[actualChair].GetComponent<FurnitureCaracteristics>().Popularity < Chair[numToy].GetComponent<FurnitureCaracteristics>().Popularity)
        {
            Chair[actualChair].GetComponent<FurnitureCaracteristics>().Popularity = Chair[numToy].GetComponent<FurnitureCaracteristics>().Popularity;
        }
        Toy[actualToy].SetActive(false);
        actualToy = numToy;
        Toy[actualToy].SetActive(true);
        saver.SaveData();
    }
    public void ChangePlant(int numPlant)
    {
        if (Chair[actualChair].GetComponent<FurnitureCaracteristics>().Popularity < Chair[numPlant].GetComponent<FurnitureCaracteristics>().Popularity)
        {
            Chair[actualChair].GetComponent<FurnitureCaracteristics>().Popularity = Chair[numPlant].GetComponent<FurnitureCaracteristics>().Popularity;
        }
        Plant[actualPlant].SetActive(false);
        actualPlant = numPlant;
        Plant[actualPlant].SetActive(true);
        saver.SaveData();
    }
    public void ChangeBox(int numBox)
    {
        if (Chair[actualChair].GetComponent<FurnitureCaracteristics>().Popularity < Chair[numBox].GetComponent<FurnitureCaracteristics>().Popularity)
        {
            Chair[actualChair].GetComponent<FurnitureCaracteristics>().Popularity = Chair[numBox].GetComponent<FurnitureCaracteristics>().Popularity;
        }
        Box[actualBox].SetActive(false);
        actualBox = numBox;
        Box[actualBox].SetActive(true);
        saver.SaveData();
    }
    
    public float GainsCoins()
    {
        resources.changeCoins(totalPopularity * totalCoins/10);
        return 60.0f;
    }
    public void VisualizeCats()
    {
        for (int i = 0; i <= 2; i++)
        {
            if (storing.catSlots[i+5] != null)
            {
                dupCats[i] = Object.Instantiate(storing.catSlots[i+5], this.transform);
                dupCats[i].transform.position = new Vector3(catSpaces[i].transform.position.x, catSpaces[i].transform.position.y-heightOutofFurniture, catSpaces[i].transform.position.z);
                dupCats[i].GetComponent<CatCaracteristics>().ChangeScaleToShop();
                dupCats[i].SetActive(true);
            }
            else
            {
                dupCats[i] = null;
            }
        }

    }
}
