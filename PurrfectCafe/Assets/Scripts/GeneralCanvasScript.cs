using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCanvasScript : MonoBehaviour
{

    public GameObject Nursery;
    public GameObject Storing;
    public GameObject Rescue;
    public GameObject Upgrades;
    public GameObject Shop;
    public ManageStoring storingScript;
    public CatSpaceController catSpace;
    public CafeController cafeController;
    public int actualGameScreen;
    public float timeToGiveCoins;
    // Start is called before the first frame update
    void Start()
    {
        actualGameScreen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeToGiveCoins--;
        if (Nursery.activeSelf)
        {
            for (int i = 0; i < storingScript.catSlots.Length; i++)
            {
                if (storingScript.catSlots[i] != null)
                {
                    storingScript.catSlots[i].GetComponent<CatCaracteristics>().ChangeScaleToNursery();
                }
            }
        }
        else if (Storing.activeSelf)
        {
            for (int i = 0; i < storingScript.catSlots.Length; i++)
            {
                if (storingScript.catSlots[i] != null)
                {
                    storingScript.catSlots[i].GetComponent<CatCaracteristics>().ChangeScaleToStoring();
                }
            }
        }
        else if (Shop.activeSelf)
        {

        }
        if (timeToGiveCoins < 0)
        {
            timeToGiveCoins=cafeController.GainsCoins();
        }
    }
    private void ChangeScreen()
    {
        if (actualGameScreen == 5)
        {
            actualGameScreen = 0;
        }
        if(actualGameScreen == -1)
        {
            actualGameScreen = 4;
        }
        if (actualGameScreen==0)
        {
            Nursery.SetActive(true);
            Storing.SetActive(false);
            Rescue.SetActive(false);
            Upgrades.SetActive(false);
            Shop.SetActive(false);
            for (int i=0;i< catSpace.dupCats.Length;i++)
            {
                if (catSpace.dupCats[i] != null)
                {
                    Destroy(catSpace.dupCats[i]);
                    catSpace.dupCats[i] = null;
                }
            }
            catSpace.VisualizeCats();
        }
        else if (actualGameScreen == 1)
        {
            Nursery.SetActive(false);
            Storing.SetActive(true);
            Rescue.SetActive(false);
            Upgrades.SetActive(false);
            Shop.SetActive(false);
        }
        else if (actualGameScreen == 2)
        {
            Nursery.SetActive(false);
            Storing.SetActive(false);
            Rescue.SetActive(true);
            Upgrades.SetActive(false);
            Shop.SetActive(false);
        }
        else if (actualGameScreen == 3)
        {
            Nursery.SetActive(false);
            Storing.SetActive(false);
            Rescue.SetActive(false);
            Upgrades.SetActive(true);
            Shop.SetActive(false);
        }
        else if (actualGameScreen == 4)
        {
            Nursery.SetActive(false);
            Storing.SetActive(false);
            Rescue.SetActive(false);
            Upgrades.SetActive(false);
            Shop.SetActive(true);
            for (int i = 0; i < cafeController.dupCats.Length; i++)
            {
                if (cafeController.dupCats[i] != null)
                {
                    Destroy(cafeController.dupCats[i]);
                    cafeController.dupCats[i] = null;
                }
            }
            cafeController.VisualizeCats();
        }
    }
    public void ArrowRight()
    {
        actualGameScreen++;
        ChangeScreen();
    }
    public void ArrowLeft()
    {
        actualGameScreen--;
        ChangeScreen();
    }
}
