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
    public bool Abilitty;
    public string TypeOfCat;
    public float probOfObtainning;//0 100
    public bool Nursery=false;
    public bool Shop=false;
    public bool Storing=false;


    // Start is called before the first frame update
    void Start()
    {
        HairBallPerClickSupp = HairBallPerClick / 4 +1;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ChangeScaleToNursery()
    {
        transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
        Storing = false;
        Nursery = true;
        Shop = false;
    }
    public void ChangeScaleToStoring()
    {
        transform.localScale = new Vector3(20.0f, 20.0f, 20.0f);
        Storing = true;
        Nursery = false;
        Shop = false;
    }
}
