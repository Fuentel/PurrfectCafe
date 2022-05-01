using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueCat : MonoBehaviour
{
    private int hairBalls = 50;
    private int coins = 50;
    private float timePut = 30.0f;
    public Text hairBallsText;
    public Text coinsText;
    public Text timeText;
    public GenerateRandomCat catgenerator;
    public ResourcesController resources;
    public GameObject NotEnough;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }
    public void IncreaseHairBalls()
    {
        hairBalls += 50;
    }public void DecreaseHairBalls()
    {
        hairBalls -= 50;
        if (hairBalls < 50)
        {
            hairBalls = 50;
        }
    }
    public void IncreaseCoins()
    {
        coins += 50;
    }public void DecreaseCoins()
    {
        coins -= 50;
        if (coins < 50)
        {
            coins = 50;
        }
    }
    public void IncreaseTime()
    {
        timePut += 30;
    }public void DecreaseTime()
    {
        timePut -= 30;
        if (timePut < 30)
        {
            timePut = 30.0f;
        }
    }
    public void NotEnoughR()
    {
        NotEnough.SetActive(false);
    }
    public void RescueButton()
    {
        if (resources.hairBallsNum < hairBalls && resources.coinsNum < coins)
        {
            NotEnough.SetActive(true);
        }
        else
        {
            catgenerator.GenerateAnspecificCat(0,0,0);
        }
    }
    void UpdateText()
    {
        hairBallsText.text = hairBalls.ToString();
        coinsText.text = coins.ToString();
        timeText.text = timePut.ToString();
    }
}
