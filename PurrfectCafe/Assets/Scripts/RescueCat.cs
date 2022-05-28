using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueCat : MonoBehaviour
{
    private int hairBalls = 50;
    private int coins = 50;
    private float timePut = 300.0f;
    private int maxHairBalls = 50000;
    private int maxCoins = 50000;
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
    // Start is called before the first frame update
    void Start()
    {
        

        audioM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (needToActivateButton)
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
            Debug.Log("empezamos");
            storing.ReleaseACatOutsideThisScreen(lastCatadded);
            Debug.Log("CatReleased2");
            if (rescuing1)
            {

                Debug.Log("if");
                Destroy(catDuppedToShow);
                Debug.Log("catDestroyedDupped");
                catDuppedToShow = null;
                lastCatadded = catgenerator.GenerateAnspecificCat(probabilityCatRescue1.x, probabilityCatRescue1.y, probabilityCatRescue1.z);
                Debug.Log("generateCat");
                catDuppedToShow = Object.Instantiate(storing.catSlots[lastCatadded], Product.transform);
                catDuppedToShow.GetComponent<CatCaracteristics>().ChangeScaleToRescue();
                catDuppedToShow.GetComponent<CatCaracteristics>().ChangeScaleToRescue();
                catDuppedToShow.GetComponent<CatCaracteristics>().Hats[catDuppedToShow.GetComponent<CatCaracteristics>().actualHat].SetActive(false);
                Debug.Log("putCat");
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
        if (timePut < 30)//clamp
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
            RescuingRn.SetActive(true);
            if (!rescuing1)
            {
                NotificationManager.CreateNotification("New Cat awaits you!","The new cat is already here, enter the app to welcome it.", ((double)timePut)/60);
                timeToRescue1 = timePut; //* 60;
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
        int probHTotal = hairBalls/maxHairBalls*100;
        int probCTotal = coins/maxCoins*100;
        int probSTotal = (int)(timePut/maxTimePut*100);

        int totalProb = probHTotal + probCTotal + probSTotal;

        int probH = probHTotal / totalProb * 100;
        int probC = probCTotal / totalProb * 100;
        int probS = probSTotal / totalProb * 100;

        #region probabilidades antiguas
        /*if ((hairBalls - coins) <50 && (hairBalls-coins)>0)
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
        }*/
        #endregion

        Vector3Int prob =new Vector3Int(probS, probC, probH);
        return prob;
    }
    void UpdateText()
    {
        hairBallsText.text = hairBalls.ToString();
        coinsText.text = coins.ToString();
        timeText.text = timePut.ToString();
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
