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
    public ManageStoring catPosition;
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
        position=catPosition.AddACat(CatToPass);
        return position;

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
