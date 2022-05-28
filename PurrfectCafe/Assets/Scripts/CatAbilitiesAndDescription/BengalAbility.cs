using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BengalAbility : CatAbility
{
    // Start is called before the first frame update
    void Start()
    {
        DescriptionCat = "Description: Bengal cats are often seen imitating tigers trying to catch their prey, in this case their toy.";
        DescriptionCatAbility = "Special Fur: This cat´s fur is one of the most valuable in the world. This cat generates 50% more hairballs.";
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
