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
    public ManageStoring storing;
    public ResourcesController resources;
    public GameObject NotEnough;
    public GameObject isFull;
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
    public void FullButton()
    {
        isFull.SetActive(false);
    }
    public void RescueButton()
    {
        if (resources.hairBallsNum < hairBalls || resources.coinsNum < coins)
        {
            Debug.Log("a");
            NotEnough.SetActive(true);
        }
        else if (storing.isFull())
        {
            isFull.SetActive(true);
        }
        else
        {
            resources.hairBallsNum -= hairBalls;
            resources.coinsNum -= coins;
            Vector3Int a = CalculateProbability();
            catgenerator.GenerateAnspecificCat(a.x,a.y,a.z);

        }
    }
    Vector3Int CalculateProbability()
    {
        int probH = 0;
        int probC = 0;
        int probS = 0;

        if ((hairBalls - coins) <50 && (hairBalls-coins)>0)
        {
            probH = 50;
            probC = 40;
            probS = 10;
        }
        else if((hairBalls - coins) > 50 && (hairBalls - coins) < 150)
        {
            probH = 60;
            probC = 20;
            probS = 20;
        }
        else if((hairBalls - coins) > 150)
        {
            probH = 80;
            probC = 0;
            probS = 20;
        }
        if ((coins - hairBalls) < 50 && (coins - hairBalls) > 0)
        {
            probH = 40;
            probC = 50;
            probS = 10;
        }
        else if ((coins - hairBalls) > 50 && (coins - hairBalls) < 150)
        {
            probH = 20;
            probC = 60;
            probS = 20;
        }
        else if ((coins - hairBalls) > 150)
        {
            probH = 0;
            probC = 80;
            probS = 20;
        }

        if (hairBalls==coins)
        {
            probH = 40;
            probC = 40;
            probS = 10;
        }
        if (timePut>300 && (hairBalls - coins) < 50)
        {
            probH = 25;
            probC = 25;
            probS = 50;
        }

        Vector3Int prob =new Vector3Int(probS, probC, probH);
        return prob;
    }
    void UpdateText()
    {
        hairBallsText.text = hairBalls.ToString();
        coinsText.text = coins.ToString();
        timeText.text = timePut.ToString();
    }
}
