using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CottonCandyAbility : CatAbility
{
    // Start is called before the first frame update

    void Start()
    {
        DescriptionCat = "Candy Steve Description";
        DescriptionCatAbility = "Candy Steve Ability";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void AbilityOfTheCat()
    {
        Debug.Log("Coins candy" + this.GetComponent<CatCaracteristics>().CoinsPerSecond);
        this.GetComponent<CatCaracteristics>().CoinsPerSecond += (int)(this.GetComponent<CatCaracteristics>().CoinsPerSecond *0.5f);
        Debug.Log("Coins candy" + this.GetComponent<CatCaracteristics>().CoinsPerSecond);
        this.GetComponent<CatCaracteristics>().abilittyDone = true;
    }
}
