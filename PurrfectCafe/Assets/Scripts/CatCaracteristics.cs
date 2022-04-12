using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCaracteristics : MonoBehaviour
{
    public string catName;
    public string race;
    public int HairBallPerClick;
    public int HairBallPerClickSupp;
    public int CoinsPerSecond;
    public bool Abilitty;
    public string TypeOfCat;
    public float probOfObtainning; //0 100
    // Start is called before the first frame update
    void Start()
    {
        HairBallPerClickSupp = HairBallPerClick / 4 +1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
