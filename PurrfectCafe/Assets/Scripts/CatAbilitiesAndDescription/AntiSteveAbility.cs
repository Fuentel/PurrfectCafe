using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSteveAbility : CatAbility
{
    public ManageStoring storing;
    public GameObject[] aux;
    public GameObject generalCanvas;
    // Start is called before the first frame update
    private void Awake()
    {
        aux = GameObject.FindGameObjectsWithTag("GeneralCanvas");
        generalCanvas = aux[0];
        storing = generalCanvas.GetComponent<ManageStoring>();
    }
    void Start()
    {
        DescriptionCat = "Description: Sometime these cats are mistake as cars lights because of their almost total reflection of light.";
        DescriptionCatAbility = "Positive-Meow:When both this cat and its counterpart are in the café a strange energy surrounds them.This cat gains 150 % more hairballs when Steven is in the Nursery.";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void AbilityOfTheCat()
    {
        
        if (CheckForSteve() && storing!=null)
        {
            Debug.Log("Coins steve" + this.GetComponent<CatCaracteristics>().CoinsPerSecond);
            this.GetComponent<CatCaracteristics>().CoinsPerSecond += (int)(this.GetComponent<CatCaracteristics>().CoinsPerSecond * 1.5f);
            Debug.Log("Coins steve" + this.GetComponent<CatCaracteristics>().CoinsPerSecond);
            this.GetComponent<CatCaracteristics>().abilittyDone = true;
        }
    }
    bool CheckForSteve()
    {
        bool check = false;
        for (int i = 0; i < 5; i++)
        {
            if (storing.catSlots[i] != null)
            {
                if (storing.catSlots[i].GetComponent<CatCaracteristics>().race == "Steve")
                {
                    check = true;
                    break;
                }
            }
        }
        return check;
    }
}
