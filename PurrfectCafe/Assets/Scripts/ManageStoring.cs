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
    private bool clickedOnChange;
    public ManageCatPosition manageCats;
    // Start is called before the first frame update
    void Start()
    {
        ClickPanel.SetActive(false);
        clickedOnChange = false;
        for (int i = 0; i < 8; i++)
        {
            catSlots[i] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateCatsPosition()
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
            manageCats.ChangeSuppCat3(catSlots[3]);
        }
        if (catSlots[4] != null)
        {
            manageCats.ChangeSuppCat4(catSlots[4]);
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
        for (int i=8; i < catSlots.Length-1; i++)
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
        ClickPanel.SetActive(false);
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
        AllButtonsFunction(1);
    }
    public void ClickOnCatSlot2()
    {
        AllButtonsFunction(2);
    }
    public void ClickOnCatSlot3()
    {
        AllButtonsFunction(3);
    }
    public void ClickOnCatSlot4()
    {
        AllButtonsFunction(4);
    }
    public void ClickOnCatSlot5()
    {
        AllButtonsFunction(5);
    }
    public void ClickOnCatSlot6()
    {
        AllButtonsFunction(6);
    }
    public void ClickOnCatSlot7()
    {
        AllButtonsFunction(7);
    }
    public void ClickOnCatSlot8()
    {
        AllButtonsFunction(8);
    }
    public void ClickOnCatSlot9()
    {
        AllButtonsFunction(9);    
    }
    private void AllButtonsFunction(int index)
    {
        if (clickedOnChange)
        {
            GameObject aux;
            aux = catSlots[actualCat];
            catSlots[actualCat] = catSlots[index * actualStorageScreen - 1];
            catSlots[index * actualStorageScreen - 1] = aux;
            //ChangeImages(); //por hacer
            clickedOnChange = false;
            UpdateCatsPosition();
            ClickPanel.SetActive(false);
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = index * actualStorageScreen - 1;
        }
    }

}
