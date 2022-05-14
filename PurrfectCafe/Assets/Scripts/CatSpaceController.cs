using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpaceController : MonoBehaviour
{
    public ResourcesController resources;
    public ManageCatPosition catPosition;
    public ManageStoring storing;
    public GameObject[] dupCats;
    public GameObject[] catSpaces;
    public float upgradeMultiplier = 1;
    public float upgradeMainMultiplier = 1;
    public float upgradeSuppMultiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {

    }
    // Update is called once per frame
    public void GenerateHairballs()
    {
        Debug.Log("hairball");
        if (catPosition.currentMainCat != null) 
        {
            Debug.Log("a");
            resources.changeHairBalls(catPosition.currentMainCat.GetComponent<CatCaracteristics>().HairBallPerClick * upgradeMainMultiplier * upgradeMultiplier);
        }
        if (catPosition.catSupp1 != null)
        {
            resources.changeHairBalls(catPosition.catSupp1.GetComponent<CatCaracteristics>().HairBallPerClickSupp * upgradeMultiplier * upgradeSuppMultiplier);
        }
        if (catPosition.catSupp2 != null)
        {
            resources.changeHairBalls(catPosition.catSupp2.GetComponent<CatCaracteristics>().HairBallPerClickSupp * upgradeMultiplier * upgradeSuppMultiplier);
        }
        if (catPosition.catSupp3 != null)
        {
            resources.changeHairBalls(catPosition.catSupp3.GetComponent<CatCaracteristics>().HairBallPerClickSupp * upgradeMultiplier * upgradeSuppMultiplier);

        }
        if (catPosition.catSupp4 != null)
        {
            resources.changeHairBalls(catPosition.catSupp4.GetComponent<CatCaracteristics>().HairBallPerClickSupp * upgradeMultiplier * upgradeSuppMultiplier);

        }
    }
    public void VisualizeCats()
    {
        for(int i = 0; i <= 4; i++)
        {
            if (storing.catSlots[i] != null)
            {
                dupCats[i] = Object.Instantiate(storing.catSlots[i], catSpaces[i].transform);
                dupCats[i].transform.position = catSpaces[i].transform.position;
                if (i == 0)
                {
                    dupCats[i].GetComponent<CatCaracteristics>().ChangeScaleToNursery();
                }
                else
                {
                    dupCats[i].GetComponent<CatCaracteristics>().ChangeScaleToStoring();
                }
                dupCats[i].SetActive(true);
            }
            else
            {
                dupCats[i] = null;
            }
        }

    }
}
