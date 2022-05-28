using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteveAbility : CatAbility
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
        DescriptionCat = "Description: You could stare at these cats’ eyes for years and still see new things, their eyeballs are like a space in miniature.";
        DescriptionCatAbility = "Negative-Meow:When both this cat and its counterpart are in the café a strange energy surrounds them.This cat gains 150 % more hairballs when Anti-Steven is in the Cafe.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void AbilityOfTheCat()
    {
        if (CheckForAntiSteve() && storing!=null)
        {
            Debug.Log("hairball steve" + this.GetComponent<CatCaracteristics>().HairBallPerClick);
            this.GetComponent<CatCaracteristics>().HairBallPerClick += (int)(this.GetComponent<CatCaracteristics>().HairBallPerClick * 1.5f);
            Debug.Log("hairball steve" + this.GetComponent<CatCaracteristics>().HairBallPerClick);
            this.GetComponent<CatCaracteristics>().abilittyDone = true;
        }
    }
    bool CheckForAntiSteve()
    {
        bool check=false;
        for(int i = 5; i < 8; i++)
        {
            if (storing.catSlots[i] != null)
            {
                if (storing.catSlots[i].GetComponent<CatCaracteristics>().race == "AntiSteve")
                {
                    check = true;
                    break;
                }
            }
        }
        return check;
    }
}
