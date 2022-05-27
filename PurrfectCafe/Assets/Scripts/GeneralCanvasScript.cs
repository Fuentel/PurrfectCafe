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
    public GameObject Menu;
    public GameObject Game;
    public GameObject IAP;
    public ManageStoring storingScript;
    public CatSpaceController catSpace;
    public CafeController cafeController;
    public int actualGameScreen;
    public float timeToGiveCoins;
    private AudioManager audioM;
    // Start is called before the first frame update
    void Start()
    {
        actualGameScreen = 0;
        audioM = FindObjectOfType<AudioManager>();
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
        if (actualGameScreen == 6)
        {
            actualGameScreen = 0;
        }
        if(actualGameScreen == -1)
        {
            actualGameScreen = 5;
        }
        if (actualGameScreen == 0)
        {
            Menu.SetActive(false);
            Nursery.SetActive(true);
            Storing.SetActive(false);
            Rescue.SetActive(false);
            Upgrades.SetActive(false);
            Shop.SetActive(false);
            IAP.SetActive(false);
            for (int i = 0; i < catSpace.dupCats.Length; i++)
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
            Menu.SetActive(false);
            Nursery.SetActive(false);
            Storing.SetActive(true);
            Rescue.SetActive(false);
            Upgrades.SetActive(false);
            Shop.SetActive(false);
            IAP.SetActive(false);
            storingScript.clickedOnChange = false;
            storingScript.ClickPanel.SetActive(false);
        }
        else if (actualGameScreen == 2)
        {
            Menu.SetActive(false);
            Nursery.SetActive(false);
            Storing.SetActive(false);
            Rescue.SetActive(true);
            Upgrades.SetActive(false);
            Shop.SetActive(false);
            IAP.SetActive(false);
        }
        else if (actualGameScreen == 3)
        {
            Menu.SetActive(false);
            Nursery.SetActive(false);
            Storing.SetActive(false);
            Rescue.SetActive(false);
            Upgrades.SetActive(true);
            Shop.SetActive(false);
            IAP.SetActive(false);
        }
        else if (actualGameScreen == 4)
        {
            Menu.SetActive(false);
            Nursery.SetActive(false);
            Storing.SetActive(false);
            Rescue.SetActive(false);
            Upgrades.SetActive(false);
            Shop.SetActive(true);
            IAP.SetActive(false);
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
        else if (actualGameScreen == 5)
        { 
            Menu.SetActive(false);
            Nursery.SetActive(false);
            Storing.SetActive(false);
            Rescue.SetActive(false);
            Upgrades.SetActive(false);
            Shop.SetActive(false);
            IAP.SetActive(true);
        }
    }
    public void MenuButton()
    {
        Game.SetActive(true);
        Menu.SetActive(false);
        actualGameScreen = 0;
        ChangeScreen();
        audioM.Play("Click");

    }
    public void ArrowRight()
    {
        actualGameScreen++;
        ChangeScreen();
        audioM.Play("Click");
    }
    public void ArrowLeft()
    {
        actualGameScreen--;
        ChangeScreen();
        audioM.Play("Click");
    }
}
