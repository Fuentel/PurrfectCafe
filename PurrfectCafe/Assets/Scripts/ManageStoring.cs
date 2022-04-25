using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageStoring : MonoBehaviour
{
    public GameObject[] catSlots=new GameObject[36];//= new CatCaracteristics[9* numerOfScreens]
    private int actualStorageScreen = 1;
    private int actualCat = 0;
    public GameObject ClickPanel;
    public Button Cafe;
    public Button Nursery;
    public bool clickedOnChange;
    public ManageCatPosition manageCats;
    // Start is called before the first frame update
    void Start()
    {
        ClickPanel.SetActive(false);
        clickedOnChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCatsPosition()
    {
        manageCats.ChangeMainCat(catSlots[0]);
        if (catSlots[1]!=null) 
        {
            manageCats.ChangeSuppCat1(catSlots[1]);
        }
        if (catSlots[2] != null)
        {
            manageCats.ChangeSuppCat2(catSlots[2]);
        }
        if (catSlots[3] != null)
        {
            manageCats.ChangeSuppCat2(catSlots[3]);
        }
        if (catSlots[4] != null)
        {
            manageCats.ChangeSuppCat2(catSlots[4]);
        }


        if (catSlots[5] != null)
        {
            manageCats.ChangeCoinCat1(catSlots[5]);
        }
        if (catSlots[6] != null)
        {
            manageCats.ChangeCoinCat2(catSlots[6]);
        }
        if (catSlots[7] != null)
        {
            manageCats.ChangeCoinCat3(catSlots[7]);
        }
        for (int i=0; i < catSlots.Length-1; i++)
        {
            if (catSlots[i+1] != null && catSlots[i]==null)
            {
                catSlots[i] = catSlots[i + 1];
                catSlots[i+1] = null;
            }
        }
    }
    public void ClickOnRelease()
    {
        catSlots[actualCat] = null;
        UpdateCatsPosition();
    }
    public void ClickOnCancel()
    {
        ClickPanel.SetActive(false);
        Nursery.gameObject.SetActive(true);
        Cafe.gameObject.SetActive(true);
    }
    public void ClickOnChange()
    {
        clickedOnChange = true;
    }
    public void ClickOnCatSlot1()
    {
        if (clickedOnChange)
        {
            GameObject aux;
            aux = catSlots[actualCat];
            catSlots[actualCat] = catSlots[1 * actualStorageScreen-1];
            catSlots[1 * actualStorageScreen] = catSlots[actualCat];
            //ChangeImages(); //por hacer
            clickedOnChange = false;
            UpdateCatsPosition();
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = 1 * actualStorageScreen-1;
        }
    }
    public void ClickOnCatSlot2()
    {
        if (clickedOnChange)
        {
            GameObject aux;
            aux = catSlots[actualCat];
            catSlots[actualCat] = catSlots[2 * actualStorageScreen-1];
            catSlots[2 * actualStorageScreen] = catSlots[actualCat];
            //ChangeImages(); //por hacer
            clickedOnChange = false;
            UpdateCatsPosition();
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = 2 * actualStorageScreen-1;
        }
    }
    public void ClickOnCatSlot3()
    {
        if (clickedOnChange)
        {
            GameObject aux;
            aux = catSlots[actualCat];
            catSlots[actualCat] = catSlots[3 * actualStorageScreen-1];
            catSlots[3 * actualStorageScreen] = catSlots[actualCat];
            //ChangeImages(); //por hacer
            clickedOnChange = false;
            UpdateCatsPosition();
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = 3 * actualStorageScreen-1;
        }
    }
    public void ClickOnCatSlot4()
    {
        if (clickedOnChange)
        {
            GameObject aux;
            aux = catSlots[actualCat];
            catSlots[actualCat] = catSlots[4 * actualStorageScreen-1];
            catSlots[4 * actualStorageScreen] = catSlots[actualCat];
            //ChangeImages(); //por hacer
            clickedOnChange = false;
            UpdateCatsPosition();
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = 4 * actualStorageScreen-1;
        }
    }
    public void ClickOnCatSlot5()
    {
        if (clickedOnChange)
        {
            GameObject aux;
            aux = catSlots[actualCat];
            catSlots[actualCat] = catSlots[5 * actualStorageScreen-1];
            catSlots[5 * actualStorageScreen] = catSlots[actualCat];
            //ChangeImages(); //por hacer
            clickedOnChange = false;
            UpdateCatsPosition();
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = 5 * actualStorageScreen-1;
        }
    }
    public void ClickOnCatSlot6()
    {
        if (clickedOnChange)
        {
            GameObject aux;
            aux = catSlots[actualCat];
            catSlots[actualCat] = catSlots[6 * actualStorageScreen-1];
            catSlots[6 * actualStorageScreen] = catSlots[actualCat];
            //ChangeImages(); //por hacer
            clickedOnChange = false;
            UpdateCatsPosition();
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = 6 * actualStorageScreen-1;
        }
    }
    public void ClickOnCatSlot7()
    {
        if (clickedOnChange)
        {
            GameObject aux;
            aux = catSlots[actualCat];
            catSlots[actualCat] = catSlots[7 * actualStorageScreen-1];
            catSlots[7 * actualStorageScreen] = catSlots[actualCat];
            //ChangeImages(); //por hacer
            clickedOnChange = false;
            UpdateCatsPosition();
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = 7 * actualStorageScreen-1;
        }
    }
    public void ClickOnCatSlot8()
    {
        if (clickedOnChange)
        {
            GameObject aux;
            aux = catSlots[actualCat];
            catSlots[actualCat] = catSlots[8 * actualStorageScreen-1];
            catSlots[8 * actualStorageScreen] = catSlots[actualCat];
            //ChangeImages(); //por hacer
            clickedOnChange = false;
            UpdateCatsPosition();
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = 8 * actualStorageScreen-1;
        }
    }
    public void ClickOnCatSlot9()
    {
        if (clickedOnChange)
        {
            GameObject aux;
            aux = catSlots[actualCat];
            catSlots[actualCat] = catSlots[9 * actualStorageScreen-1];
            catSlots[9 * actualStorageScreen] = catSlots[actualCat];
            //ChangeImages(); //por hacer
            clickedOnChange = false;
            UpdateCatsPosition();
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = 9 * actualStorageScreen-1;
        }
    }
    

}
