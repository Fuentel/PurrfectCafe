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
        DescriptionCat = "Steve Description";
        DescriptionCatAbility = "Steve Ability";

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
