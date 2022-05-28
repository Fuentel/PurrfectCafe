using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatCaracteristics : MonoBehaviour
{
    public string catName;
    public string race;
    public int HairBallPerClick;
    public int HairBallPerClickSupp;
    public int CoinsPerSecond;
    public int Popularity;
    public bool Abilitty;
    public bool abilittyDone=false;
    public string TypeOfCat;
    public float probOfObtainning;//0 100
    public bool Nursery=false;
    public bool Shop=false;
    public bool Storing=false;
    public GameObject[] Hats;
    public int actualHat;
    private float slotScale= 0.2f;
    private float suppScale= 0.2f;
    private float rescueScale= 1;
    private float catSpaceScale=0.9f;
    private float cofeSpaceScale=0.2f;
    

    // Start is called before the first frame update
    void Start()
    {
        if (Abilitty)
        {
            this.GetComponent<CatAbility>().AbilityOfTheCat();
        }
        HairBallPerClickSupp = HairBallPerClick / 4 +1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Abilitty && !abilittyDone)
        {
            this.GetComponent<CatAbility>().AbilityOfTheCat();
        }
    }
    public void ChangeScaleToNursery()
    {
        transform.localScale = new Vector3(catSpaceScale, catSpaceScale, catSpaceScale);
        Storing = false;
        Nursery = true;
        Shop = false;
    }
    public void ChangeScaleToStoring()
    {
        transform.localScale = new Vector3(slotScale, slotScale, slotScale);
        Storing = true;
        Nursery = false;
        Shop = false;
    }
    public void ChangeScaleToSupp()
    {
        transform.localScale = new Vector3(suppScale, suppScale, suppScale);
        Storing = true;
        Nursery = false;
        Shop = false;
    }
    public void ChangeScaleToRescue()
    {
        transform.localScale = new Vector3(rescueScale, rescueScale, rescueScale);
        Storing = true;
        Nursery = false;
        Shop = false;
    }
    public void ChangeScaleToShop()
    {
        transform.localScale = new Vector3(cofeSpaceScale, cofeSpaceScale, cofeSpaceScale);
        Storing = true;
        Nursery = false;
        Shop = false;
    }
}
