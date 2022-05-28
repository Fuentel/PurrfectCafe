using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunchkinAbility : CatAbility
{
    // Start is called before the first frame update
    void Start()
    {

        DescriptionCat = "Description: This cat gets anxious when they are alone, so when they finally found someone, they keep following them forever.";
        DescriptionCatAbility = "Friendly-Paws: This cat social skills are through the roof. This cat generates 50 % more hairballs in the support position";

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void AbilityOfTheCat()
    {
        if (this.GetComponent<CatCaracteristics>().HairBallPerClickSupp != 0)
        {
            this.GetComponent<CatCaracteristics>().HairBallPerClickSupp += (int)(this.GetComponent<CatCaracteristics>().HairBallPerClick * 0.5f);
            this.GetComponent<CatCaracteristics>().abilittyDone = true;
        }
        
    }
}
