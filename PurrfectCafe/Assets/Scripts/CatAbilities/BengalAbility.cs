using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BengalAbility : CatAbility
{
    // Start is called before the first frame update
    void Start()
    {
        DescriptionCat = "Bengal Steve Description";
        DescriptionCatAbility = "Bengal Steve Ability";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void AbilityOfTheCat()
    {
        Debug.Log("Hair Bengal" + this.GetComponent<CatCaracteristics>().CoinsPerSecond);
        this.GetComponent<CatCaracteristics>().HairBallPerClick += (int)(this.GetComponent<CatCaracteristics>().HairBallPerClick * 0.5f);
        Debug.Log("Hair Bengal" + this.GetComponent<CatCaracteristics>().CoinsPerSecond);
        this.GetComponent<CatCaracteristics>().abilittyDone = true;
    }
}
