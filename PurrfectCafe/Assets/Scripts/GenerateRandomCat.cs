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
    public ManageCatPosition catPosition;

    private GameObject CatToPass;
    private int typeOfCat = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectCatType();
            CreateCat();
            CatToPass.transform.position = Vector3.zero;
            catPosition.ChangeMainCat(CatToPass);
        }
    }
    void SelectCatType()
    {
        float randomNum = Random.Range(0,100);
        if (randomNum > 50)
        {
            typeOfCat = 0;
        }else{

            typeOfCat = 1;

        }

    }
    void CreateCat()
    {
        float ranNum = Random.Range(0, 100);
        int numCat;
        switch (typeOfCat)
        {
            case 0:
                numCat = StandardCat(ranNum);
                switch (numCat)
                {
                    case 0:
                        CatToPass = Object.Instantiate(SiamesPrefab, this.transform.position, Quaternion.identity);
                        break;
                    case 1:
                        CatToPass = Object.Instantiate(BlueRussianPrefab, this.transform.position, Quaternion.identity);
                        break;
                    case 2:
                        CatToPass = Object.Instantiate(EuropeanOrangePrefab, this.transform.position, Quaternion.identity);
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
                        CatToPass = Object.Instantiate(CottonCandyPrefab, this.transform.position, Quaternion.identity);
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
                        CatToPass = Object.Instantiate(BengalPrefab, this.transform.position, Quaternion.identity);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        } 
    }
    //ordenar los gatos de mayor a menor probabilidad
    int StandardCat(float rNum)
    {
        int numCat = 0;
        if (SiamesPrefab.GetComponent<CatCaracteristics>().probOfObtainning >= rNum)
        {
            numCat = 0;
        }
        else if (BlueRussianPrefab.GetComponent<CatCaracteristics>().probOfObtainning >= rNum)
        {
            numCat = 1;
        }
        else if(EuropeanOrangePrefab.GetComponent<CatCaracteristics>().probOfObtainning >= rNum)
        {
            numCat = 2;
        }

        return numCat;
    }
    int ShopperCat(float rNum)
    {
        int numCat = 0;
        if (CottonCandyPrefab.GetComponent<CatCaracteristics>().probOfObtainning < rNum)
        {
            numCat = 0;
        }

        return numCat;
    }
    int HairyCat(float rNum)
    {
        int numCat = 0;
        if (BengalPrefab.GetComponent<CatCaracteristics>().probOfObtainning < rNum)
        {
            numCat = 0;
        }

        return numCat;
    }
}
