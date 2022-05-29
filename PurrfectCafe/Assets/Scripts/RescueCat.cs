using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueCat : MonoBehaviour
{
    private int hairBalls = 50;
    private int coins = 50;
    public float timePut = 300.0f;
    private int maxHairBalls = 3000;
    private int maxCoins = 3000;
    private float maxTimePut = 172800.0f;//two days
    public float timeToRescue1;
    public Vector3Int probabilityCatRescue1;
    public bool rescuing1;
    public bool needToActivateButton;
    public Text hairBallsText;
    public Text coinsText;
    public Text timeText;
    public Text timeLeftText;
    public GenerateRandomCat catgenerator;
    public ManageStoring storing;
    public ResourcesController resources;
    public GameObject NotEnough;
    public GameObject isFull;
    public GameObject AlrRescueButton1;
    public GameObject NewCatArrived;
    public GameObject Product;
    public GameObject catDuppedToShow;
    public GameObject RescuingRn;
    public Button rescueBtt;
    public int lastCatadded = -1;
    private AudioManager audioM;
    public SavingManager saver;
    public TimeOutOfAppController timeCtrl;
    private bool timeCalculated;
    // Start is called before the first frame update
    void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
        timeCalculated = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (saver.loaded && !timeCalculated)
        {
            Debug.Log("old" + timeToRescue1);
            timeToRescue1 -= timeCtrl.timePasedOut;
            timeCtrl.timePasedOut = 0;
            timeCalculated = true;
            Debug.Log("new time"+timeToRescue1);
        }
        UpdateText();
        if (timeToRescue1 > 0.0f && rescuing1)
        {
            timeToRescue1 -= Time.deltaTime;
            RescuingRn.SetActive(true);
        }
        else if(rescuing1 && timeToRescue1 < 0.0f)
        {
            needToActivateButton = true;
            timeToRescue1 = 0.0f;
        }
        if (needToActivateButton && !AlrRescueButton1.activeInHierarchy)
        {
            AlrRescueButton1.SetActive(true);
            saver.SaveData();
        }
        if (rescuing1)
        {
            rescueBtt.interactable = false;
        }
        else
        {
            rescueBtt.interactable = true;
        }
    }
    public void AlreadyRescueButton1()
    {
        lastCatadded=catgenerator.GenerateAnspecificCat(probabilityCatRescue1.x, probabilityCatRescue1.y, probabilityCatRescue1.z);
        AlrRescueButton1.SetActive(false);
        RescuingRn.SetActive(false);
        needToActivateButton = false;
        NewCatArrived.SetActive(true);
        Destroy(catDuppedToShow);
        catDuppedToShow = null;
        catDuppedToShow = Object.Instantiate(storing.catSlots[lastCatadded], Product.transform);
        catDuppedToShow.GetComponent<CatCaracteristics>().ChangeScaleToRescue();
        catDuppedToShow.GetComponent<CatCaracteristics>().Hats[catDuppedToShow.GetComponent<CatCaracteristics>().actualHat].SetActive(false);
    }
    public void DeleteCatAdded()
    {
        if (lastCatadded != -1)
        {
            storing.ReleaseACatOutsideThisScreen(lastCatadded);
            if (rescuing1)
            {

                Destroy(catDuppedToShow);
                catDuppedToShow = null;
                lastCatadded = catgenerator.GenerateAnspecificCat(probabilityCatRescue1.x, probabilityCatRescue1.y, probabilityCatRescue1.z);
                catDuppedToShow = Object.Instantiate(storing.catSlots[lastCatadded], Product.transform);
                catDuppedToShow.GetComponent<CatCaracteristics>().ChangeScaleToRescue();
                catDuppedToShow.GetComponent<CatCaracteristics>().ChangeScaleToRescue();
                catDuppedToShow.GetComponent<CatCaracteristics>().Hats[catDuppedToShow.GetComponent<CatCaracteristics>().actualHat].SetActive(false);
            }
        }

    }
    public void ContinueWithThisCat()
    {
        rescuing1 = false;
        NewCatArrived.SetActive(false);
        lastCatadded = -1;
        audioM.Play("Click");
        saver.SaveData();
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
        if (hairBalls > maxHairBalls)//clamp
        {
            hairBalls = maxHairBalls;
        }
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
        if (coins > maxCoins)//clamp
        {
            coins = maxCoins;
        }
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
        if (timePut < 500)
        {
            timePut += 30;
        }
        else if(timePut < 2000)
        {
            timePut += 120;
        }
        else if (timePut < 10000)
        {
            timePut += 360;
        }
        else
        {
            timePut += 1440;
        }
        if (timePut > maxTimePut)//clamp
        {
            timePut = maxTimePut;
        }

        audioM.Play("Click");
    }
    public void DecreaseTime()
    {
        if (timePut < 500)
        {
            timePut -= 30;
        }
        else if (timePut < 2000)
        {
            timePut -= 120;
        }
        else if (timePut < 10000)
        {
            timePut -= 360;
        }
        else
        {
            timePut -= 1440;
        }
        if (timePut < 60)//clamp
        {
            timePut = 60.0f;
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
            RescuingRn.SetActive(true);
            if (!rescuing1)
            {
                NotificationManager.CreateNotification("New Cat awaits you!","The new cat is already here, enter the app to welcome it.", ((double)timePut)/60);
                NotificationManager.CreateNotification("Your cat is half way here!","Don´t you want to prepare the shop before it gets here.", (((double)timePut)/60)/2);
                timeToRescue1 = timePut;
                rescuing1 = true;
                saver.SaveData();
            }
        }
        audioM.Play("Click");
    }
    void GenerateProbability()
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
        int probH;
        int probC;
        float probHTotal = (hairBalls/maxHairBalls)*100;
        float probCTotal = (coins/maxCoins)*100;
        float probSTotal = (timePut/maxTimePut)*100;

        int probS = (int)((probHTotal + probCTotal + probSTotal)/3);
        Debug.Log("probHTotal" + probHTotal + "   probCTotal" + probCTotal + "probSTotal" + probSTotal);
        Debug.Log("Special"+probS);
        Debug.Log(((probHTotal + probCTotal + probSTotal) / 3));
        int restProb = 100 - probS;
        if(probHTotal >= probCTotal)
        {
            float difference = (probHTotal - probCTotal) * (restProb/100);
            probH = (int)(restProb * 0.5f + difference);
            probC = restProb - probH;
        }
        else
        {
            float difference = (probCTotal - probHTotal) * (restProb / 100);
            probC = (int)(restProb * 0.5f + difference);
            probH = restProb - probC;
        }

        Vector3Int prob =new Vector3Int((int)probS, (int)probC, (int)probH);
        Debug.Log(prob);
        return prob;
    }
    void UpdateText()
    {
        hairBallsText.text = hairBalls.ToString();
        coinsText.text = coins.ToString();
        timeText.text = ConvertToTime(timePut);
        timeLeftText.text = "Time Left: "+ConvertToTime(timeToRescue1);

    }
    string ConvertToTime(float time)
    {
        string text = "";

        int minutes = (int)time / 60;
        int seconds = (int)(time - (minutes * 60));
        text = minutes+":"+ seconds;
        return text;
    }
}
