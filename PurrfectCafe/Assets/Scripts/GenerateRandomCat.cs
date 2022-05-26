using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomCat : MonoBehaviour
{
    public GameObject CottonCandyPrefab;
    public GameObject BlueRussianPrefab;
    public GameObject EuropeanOrangePrefab;
    public GameObject SiamesPrefab;
    public GameObject BengalPrefab;
    public GameObject AntiStevePrefab;
    public GameObject StevePrefab;
    public GameObject MunchkinPrefab;
    public GameObject NullPrefab;
    public ManageStoring storing;
    public GameObject GeneralCanvasObj;

    private GameObject CatToPass;
    private int typeOfCat = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GenerateAnspecificCat(int probSpecial, int probShopper, int probHairy)
    {
        int position = 0;
        SelectCatType(probSpecial, probShopper, probHairy);
        CreateCat();
        position=storing.AddACat(CatToPass);
        return position;

    }
    public  void AddACatInPosition(string race, int position)
    {
        int slotBoxToParent = 0;
        if (position < 9)
        {
            slotBoxToParent = 0;
        }
        else if (position < 18)
        {
            slotBoxToParent = 1;
        }
        else if (position < 27)
        {
            slotBoxToParent = 2;
        }
        else if (position < 36)
        {
            slotBoxToParent = 3;
        }
        GameObject catToAdd = null;
        if(race== "Siames")
        {
            catToAdd= Object.Instantiate(SiamesPrefab, GeneralCanvasObj.transform);
        }else if(race== "AntiSteve")
        {
            catToAdd= Object.Instantiate(AntiStevePrefab, GeneralCanvasObj.transform);
        }else if(race== "Bengal")
        {
            catToAdd= Object.Instantiate(BengalPrefab, GeneralCanvasObj.transform);
        }else if(race== "BlueRussian")
        {
            catToAdd= Object.Instantiate(BlueRussianPrefab, GeneralCanvasObj.transform);
        }else if(race== "CottonCandy")
        {
            catToAdd= Object.Instantiate(CottonCandyPrefab, GeneralCanvasObj.transform);
        }else if(race== "EuropeanOrange")
        {
            catToAdd= Object.Instantiate(EuropeanOrangePrefab, GeneralCanvasObj.transform);
        }else if(race== "Munchkin")
        {
            catToAdd= Object.Instantiate(MunchkinPrefab, GeneralCanvasObj.transform);
        }else if(race== "Null")
        {
            catToAdd= Object.Instantiate(NullPrefab, GeneralCanvasObj.transform);
        }else if(race== "Steve")
        {
            catToAdd= Object.Instantiate(StevePrefab, GeneralCanvasObj.transform);
        }
        catToAdd.transform.SetParent(storing.slotBoxes[slotBoxToParent].transform);
        storing.catSlots[position] = catToAdd;
        storing.UpdateCatsPosition();
    }
    private void SelectCatType(int probSpecial,int probShopper, int probHairy)
    {
        int randomNum = Random.Range(0,100);
        if (randomNum < probSpecial)
        {
            typeOfCat = 0;
        }
        else if (randomNum < probShopper+probSpecial)
        {
            typeOfCat = 1;
        }
        else if(randomNum <= probShopper + probSpecial+probHairy)
        {
            typeOfCat = 2;
        }
        
    }
    private void CreateCat()
    {
        float ranNum = Random.Range(0, 100);
        int numCat;
        switch (typeOfCat)
        {
            case 0:
                numCat = SpecialCat(ranNum);
                switch (numCat)
                {
                    case 0:
                        CatToPass = Object.Instantiate(SiamesPrefab, GeneralCanvasObj.transform);
                        break;
                    case 1:
                        CatToPass = Object.Instantiate(BlueRussianPrefab, GeneralCanvasObj.transform);
                        break;
                    case 2:
                        CatToPass = Object.Instantiate(EuropeanOrangePrefab, GeneralCanvasObj.transform);
                        break;
                    default:
                        break;
                }
                break;
            case 1:
                numCat = ShopperCat(ranNum);
                switch (numCat)
                {
                    case 0:
                        CatToPass = Object.Instantiate(CottonCandyPrefab, GeneralCanvasObj.transform);
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                numCat = HairyCat(ranNum);
                switch (numCat)
                {
                    case 0:
                        CatToPass = Object.Instantiate(BengalPrefab, GeneralCanvasObj.transform);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        } 
    }
    int SpecialCat(float rNum)
    {
        int numCat = 0;
        if (rNum < SiamesPrefab.GetComponent<CatCaracteristics>().probOfObtainning)
        {
            numCat = 0;
        }
        else if (rNum < BlueRussianPrefab.GetComponent<CatCaracteristics>().probOfObtainning + SiamesPrefab.GetComponent<CatCaracteristics>().probOfObtainning)
        {
            numCat = 1;
        }
        else if(rNum <= EuropeanOrangePrefab.GetComponent<CatCaracteristics>().probOfObtainning + BlueRussianPrefab.GetComponent<CatCaracteristics>().probOfObtainning + SiamesPrefab.GetComponent<CatCaracteristics>().probOfObtainning)
        {
            numCat = 2;
        }

        return numCat;
    }
    int ShopperCat(float rNum)
    {
        int numCat = 0;
        if (rNum < CottonCandyPrefab.GetComponent<CatCaracteristics>().probOfObtainning)
        {
            numCat = 0;
        }

        return numCat;
    }
    int HairyCat(float rNum)
    {
        int numCat = 0;
        if (rNum < BengalPrefab.GetComponent<CatCaracteristics>().probOfObtainning)
        {
            numCat = 0;
        }

        return numCat;
    }

}
