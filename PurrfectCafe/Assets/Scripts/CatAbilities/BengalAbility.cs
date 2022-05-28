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
        this.GetComponent<CatCaracteristics>().HairBallPerClick += (int)(this.GetComponent<CatCaracteristics>().HairBallPerClick * 0.5f);
        this.GetComponent<CatCaracteristics>().abilittyDone = true;
    }
}
