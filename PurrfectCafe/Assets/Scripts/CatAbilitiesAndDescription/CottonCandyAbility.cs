using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CottonCandyAbility : CatAbility
{
    // Start is called before the first frame update

    void Start()
    {
        DescriptionCat = "Description: Even though its name is a typical sweet for your palate, don’t try to eat this cat or you will end with a few fury sweeps in your face. ";
        DescriptionCatAbility = "Bubbly Cute: People are more prone to buy special coffee when this cat is in the shop. This cat generates 50% more coins";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void AbilityOfTheCat()
    {
        this.GetComponent<CatCaracteristics>().CoinsPerSecond += (int)(this.GetComponent<CatCaracteristics>().CoinsPerSecond *0.5f);
        this.GetComponent<CatCaracteristics>().abilittyDone = true;
    }
}
