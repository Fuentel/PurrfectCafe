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
        hairBallsNum = 300;
        coinsNum = 300;
    }

    // Update is called once per frame
    void Update()
    {
        hairBallsText.text =  hairBallsNum.ToString();
        coinsText.text =  coinsNum.ToString();
        popularityText.text = popularityNum.ToString();
    }
    public void changeCoins(float sum)
    {
        if (sum < 1)
        {
            sum = 1;
        }
        coinsNum += (int)sum;
    }
    public void changeHairBalls(float sum)
    {
        if (sum < 1)
        {
            sum = 1;
        }
        hairBallsNum += (int)sum;
    }
    public void changePupularity(float sum)
    {
        if (sum < 1)
        {
            sum = 1;
        }
        popularityNum += (int)sum;
    }
}
