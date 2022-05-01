using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesController : MonoBehaviour
{
    public Text hairBallsText;
    public int hairBallsNum;
    public Text coinsText;
    public int coinsNum;
    public Text popularityText;
    public int popularityNum;

    // Start is called before the first frame update
    void Start()
    {
        hairBallsNum = 2000;
        coinsNum = 2000;
    }

    // Update is called once per frame
    void Update()
    {
        hairBallsText.text = "HairBalls: " + hairBallsNum;
        coinsText.text = "Coins: " + coinsNum;
        popularityText.text = "Popularity: " + popularityNum;
    }
    public void changeCoins(int sum)
    {
        coinsNum += sum;
    }
    public void changeHairBalls(int sum)
    {
        hairBallsNum += sum;
    }
    public void changePupularity(int sum)
    {
        popularityNum += sum;
    }
}
