using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCatPosition : MonoBehaviour
{

    public GameObject currentMainCat;
    public GameObject catSupp1;
    public GameObject catSupp2;
    public GameObject catSupp3;
    public GameObject catSupp4;
    public GameObject catCoins1;
    public GameObject catCoins2;
    public GameObject catCoins3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeMainCat(GameObject cat)
    {
        currentMainCat=cat;
    }
    public void ChangeSuppCat1(GameObject cat)
    {
        catSupp1 = cat;
    }
    public void ChangeSuppCat2(GameObject cat)
    {
        catSupp2= cat;
    }
    public void ChangeSuppCat3(GameObject cat)
    {
        catSupp3= cat;
    }
    public void ChangeSuppCat4(GameObject cat)
    {
        catSupp4= cat;
    }
    public void ChangeCoinCat1(GameObject cat)
    {
        catCoins1 = cat;
    }
    public void ChangeCoinCat2(GameObject cat)
    {
        catCoins2 = cat;
    }
    public void ChangeCoinCat3(GameObject cat)
    {
        catCoins3 = cat;
    }
}
