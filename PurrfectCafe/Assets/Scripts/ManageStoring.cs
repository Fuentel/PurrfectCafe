using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageStoring : MonoBehaviour
{
    public GameObject[] catSlots=new GameObject[36];//= new CatCaracteristics[9* numerOfScreens]
    public Transform[] buttonsTransform = new Transform[9];
    public GameObject[] slotBoxes;
    private int actualStorageScreen = 1;
    public int actualCat = 0;
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
        for (int i = 0; i < 36; i++)
        {
            catSlots[i] = null;
        }
        for (int i = 0; i < slotBoxes.Length; i++)
        {
            slotBoxes[i].SetActive(false);
        }
        slotBoxes[0].SetActive(true);
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

        if (catSlots[0] == null)
        {
            for (int i = 1; i < catSlots.Length - 1; i++)
            {

                if (catSlots[i] != null)
                {
                    catSlots[0] = catSlots[i];
                    catSlots[i] = null;
                    break;
                }
            }
        }
        for (int i=8; i < catSlots.Length-1; i++)
        {
            if (catSlots[i+1] != null && catSlots[i]==null)
            {
                catSlots[i] = catSlots[i + 1];
                catSlots[i+1] = null;
            }
        }
        //update game position
        for (int i = 0; i < catSlots.Length; i++)
        {
            if (catSlots[i] != null)
            {

                switch (i % 9)
                {
                    case 0:
                        catSlots[i].transform.position = buttonsTransform[0].position;
                        break;
                    case 1:
                        catSlots[i].transform.position = buttonsTransform[1].position;
                        break;
                    case 2:
                        catSlots[i].transform.position = buttonsTransform[2].position;
                        break;
                    case 3:
                        catSlots[i].transform.position = buttonsTransform[3].position;
                        break;
                    case 4:
                        catSlots[i].transform.position = buttonsTransform[4].position;
                        break;
                    case 5:
                        catSlots[i].transform.position = buttonsTransform[5].position;
                        break;
                    case 6:
                        catSlots[i].transform.position = buttonsTransform[6].position;
                        break;
                    case 7:
                        catSlots[i].transform.position = buttonsTransform[7].position;
                        break;
                    case 8:
                        catSlots[i].transform.position = buttonsTransform[8].position;
                        break;
                    default:
                        break;

                   }
            }
        }
    }
    public void AddACat(GameObject catToAdd)
    {
        for (int i = 0; i < catSlots.Length; i++)
        {
            if (catSlots[i] == null)
            {
                int slotBoxToParent = 0;
                if (i<9)
                {
                    slotBoxToParent = 0;
                }
                else if(i<18)
                {
                    slotBoxToParent = 1;
                }
                else if(i<27)
                {
                    slotBoxToParent = 2;
                }
                else if(i<36)
                {
                    slotBoxToParent = 3;
                }
                catToAdd.transform.parent = slotBoxes[slotBoxToParent].transform;
                catSlots[i] = catToAdd;

                break;
            }
        }
        UpdateCatsPosition();
    }
    public void ClickOnRelease()
    {
        Destroy(catSlots[actualCat]);
        catSlots[actualCat] = null;
        UpdateCatsPosition();
        ClickPanel.SetActive(false);
        Nursery.gameObject.SetActive(true);
        Cafe.gameObject.SetActive(true);
    }
    public void ClickOnCancel()
    {
        clickedOnChange = false;
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
            clickedOnChange = false;
            UpdateCatsPosition();
            ClickPanel.SetActive(false);
            Nursery.gameObject.SetActive(true);
            Cafe.gameObject.SetActive(true);
        }
        else
        {

            ClickPanel.SetActive(true);
            Nursery.gameObject.SetActive(false);
            Cafe.gameObject.SetActive(false);
            actualCat = index * actualStorageScreen - 1;
        }
    }
    public void ChangeSlotsIncrease()
    {
        actualStorageScreen++;
        slotBoxes[actualStorageScreen-1].SetActive(true);
        slotBoxes[actualStorageScreen-2].SetActive(false);
    }
    public void ChangeSlotsDecrease()
    {
        actualStorageScreen--;
        slotBoxes[actualStorageScreen - 1].SetActive(true);
        slotBoxes[actualStorageScreen + 1].SetActive(false);
    }
    public bool isFull()
    {
        bool returned = true;
        for (int i = 0; i < 36; i++)
        {
            if (catSlots[i]==null)
            {
                returned = false;
                break;
            }
        }
        return returned;
    }
}
