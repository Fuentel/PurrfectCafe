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
        DescriptionCat = "Anti Steve Description";
        DescriptionCatAbility = "Anti Steve Ability";
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
