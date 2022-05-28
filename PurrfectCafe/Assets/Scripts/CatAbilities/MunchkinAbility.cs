using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunchkinAbility : CatAbility
{
    // Start is called before the first frame update
    void Start()
    {

        DescriptionCat = "Munchkin Steve Description";
        DescriptionCatAbility = "Munchkin Steve Ability";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void AbilityOfTheCat()
    {
        if (this.GetComponent<CatCaracteristics>().HairBallPerClickSupp != 0)
        {
            Debug.Log("Munchin" + this.GetComponent<CatCaracteristics>().HairBallPerClickSupp);
            this.GetComponent<CatCaracteristics>().HairBallPerClickSupp += (int)(this.GetComponent<CatCaracteristics>().HairBallPerClick * 0.5f);
            this.GetComponent<CatCaracteristics>().abilittyDone = true;
            Debug.Log("Munchin" + this.GetComponent<CatCaracteristics>().HairBallPerClickSupp);
        }
        
    }
}
