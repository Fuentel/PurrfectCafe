using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueCat : MonoBehaviour
{
    private int hairBalls = 50;
    private int coins = 50;
    private float timePut = 300.0f;
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
