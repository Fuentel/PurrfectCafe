using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueCat : MonoBehaviour
{
    private int hairBalls = 50;
    private int coins = 50;
    private float timePut = 30.0f;
    public float timeToRescue1;
    Vector3Int probabilityCatRescue1;
    public bool rescuing1 = false;
    public Text hairBallsText;
    public Text coinsText;
    public Text timeText;
    public GenerateRandomCat catgenerator;
    public ManageStoring storing;
    public ResourcesController resources;
    public GameObject NotEnough;
    public GameObject isFull;
    public GameObject AlrRescueButton1;
    public GameObject NewCatArrived;
    public GameObject Product;
    public GameObject catDuppedToShow;
    public int lastCatadded = -1;
    private AudioManager audioM;
    // Start is called before the first frame update
    void Start()
    {
        AlrRescueButton1.SetActive(false);

        audioM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        if (timeToRescue1 > 0.0f && rescuing1)
        {
            timeToRescue1 -= Time.deltaTime;
        }
        else if(rescuing1 && timeToRescue1 < 0.0f)
        {
            AlrRescueButton1.SetActive(true); ;
            timeToRescue1 = 0.0f;
        }
    }
    public void AlreadyRescueButton1()
    {
        lastCatadded=catgenerator.GenerateAnspecificCat(probabilityCatRescue1.x, probabilityCatRescue1.y, probabilityCatRescue1.z);
        AlrRescueButton1.SetActive(false);
        NewCatArrived.SetActive(true);
        Destroy(catDuppedToShow);
        catDuppedToShow = null;
        catDuppedToShow = Object.Instantiate(storing.catSlots[lastCatadded], NewCatArrived.transform); ;
        catDuppedToShow.transform.parent = NewCatArrived.transform;
        catDuppedToShow.transform.position = Product.transform.position;
        catDuppedToShow.GetComponent<CatCaracteristics>().ChangeScaleToStoring();
    }
    public void DeleteCatAdded()
    {
        if (lastCatadded != -1)
        {
            storing.ReleaseACatOutsideThisScreen(lastCatadded);
            //anuncio
            if (rescuing1)
            {
                Destroy(catDuppedToShow);
                catDuppedToShow = null;
                lastCatadded = catgenerator.GenerateAnspecificCat(probabilityCatRescue1.x, probabilityCatRescue1.y, probabilityCatRescue1.z);
                catDuppedToShow = Object.Instantiate(storing.catSlots[lastCatadded], NewCatArrived.transform);
                catDuppedToShow.transform.parent = NewCatArrived.transform;
                catDuppedToShow.transform.position = Product.transform.position;
                catDuppedToShow.GetComponent<CatCaracteristics>().ChangeScaleToStoring();
            }
        }

    }
    public void ContinueWithThisCat()
    {
        rescuing1 = false;
        NewCatArrived.SetActive(false);
        lastCatadded = -1;
        audioM.Play("Click");
    }
    public void ChangeRecueTimeOutsideScreen(float timepased)
    {
        if (rescuing1)
        {
            timeToRescue1 -= timepased;
        }

    }
    public void IncreaseHairBalls()
    {
        hairBalls += 50;
        audioM.Play("Click");
    }
    public void DecreaseHairBalls()
    {
        hairBalls -= 50;
        if (hairBalls < 50)
        {
            hairBalls = 50;
        }
        audioM.Play("Click");
    }
    public void IncreaseCoins()
    {
        coins += 50;
        audioM.Play("Click");
    }
    public void DecreaseCoins()
    {
        coins -= 50;
        if (coins < 50)
        {
            coins = 50;
        }
        audioM.Play("Click");
    }
    public void IncreaseTime()
    {
        timePut += 30;
        audioM.Play("Click");
    }
    public void DecreaseTime()
    {
        timePut -= 30;
        if (timePut < 30)
        {
            timePut = 30.0f;
        }
        audioM.Play("Click");
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
            GenerateProbability();
            if (!rescuing1)
            {
                NotificationManager.CreateNotification("New Cat awaits you!","The new cat is already here, enter the app to welcome it.", timePut/60);
                timeToRescue1 = timePut; //* 60;
                rescuing1 = true;
            }
        }
        audioM.Play("Click");
    }
    public void GenerateProbability()
    {
        if (!rescuing1)
        {
            resources.hairBallsNum -= hairBalls;
            resources.coinsNum -= coins;
            probabilityCatRescue1 = CalculateProbability();
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
