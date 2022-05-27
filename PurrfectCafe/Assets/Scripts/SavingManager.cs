using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingManager : MonoBehaviour
{
    public ResourcesController resources;
    public ManageStoring storing;
    public RescueCat rescue;
    public CafeController cafe;
    public UpgradesHandeling upgrades;
    public GeneralCanvasScript canvas;
    public GenerateRandomCat ramCat;
    public float timeToSave = 60.0f;
    public float timePased = 60.0f;
    //al guardar
    //resources
    //tiempo de rescate
    //furniture int por cada uno para saber cual esta activo
    //storing Cats
    //Upgrades

    //al cargar
    //Upgrades Buy
    //storing Cats
    //furniture int por cada uno para saber cual esta activo
    //rescatando gato? si es asi tiempo
    //restar el tiempo del rescate
    //sumar monedas en base al tiempo
    //resources

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        timePased -= Time.deltaTime;
        if (timePased <= 0.0f)
        {
            SaveData();
            timePased = timeToSave;
        }
    }

    public void SaveData()
    {
        //resources
        PlayerPrefs.SetInt("hairballs", resources.hairBallsNum);
        PlayerPrefs.SetInt("coins", resources.coinsNum);
        PlayerPrefs.SetInt("popularity", resources.popularityNum);
        //tiempo rescate
        Debug.Log(rescue.timeToRescue1);
        PlayerPrefs.SetFloat("rescuingTime", rescue.timeToRescue1);
        Debug.Log(PlayerPrefs.GetFloat("rescuingTime"));
        if (rescue.rescuing1)
        {
            PlayerPrefs.SetInt("rescuing?", 1);
        }
        else
        {
            PlayerPrefs.SetInt("rescuing?", 0);
        }
        if (rescue.needToActivateButton)
        {
            PlayerPrefs.SetInt("needToActivateButton", 1);
        }
        else
        {
            PlayerPrefs.SetInt("needToActivateButton", 0);
        }
        PlayerPrefs.SetInt("probabilityCatRescue1x", rescue.probabilityCatRescue1.x);
        PlayerPrefs.SetInt("probabilityCatRescue1y", rescue.probabilityCatRescue1.y);
        PlayerPrefs.SetInt("probabilityCatRescue1z", rescue.probabilityCatRescue1.z);
        //Muebles activos
        PlayerPrefs.SetInt("chairInScreen", cafe.actualChair);
        if (cafe.Chair[cafe.actualChair].activeInHierarchy)
        {
            PlayerPrefs.SetInt("chairActive", 1);
        }
        else
        {
            PlayerPrefs.SetInt("chairActive", 0);
        }
        PlayerPrefs.SetInt("plantScreen", cafe.actualPlant);
        if (cafe.Plant[cafe.actualPlant].activeInHierarchy)
        {
            PlayerPrefs.SetInt("plantActive", 1);
        }
        else
        {
            PlayerPrefs.SetInt("plantActive", 0);
        }
        PlayerPrefs.SetInt("toyScreen", cafe.actualToy);
        if (cafe.Toy[cafe.actualToy].activeInHierarchy)
        {
            PlayerPrefs.SetInt("toyActive", 1);
        }
        else
        {
            PlayerPrefs.SetInt("toytActive", 0);
        }
        PlayerPrefs.SetInt("boxScreen", cafe.actualBox);
        if (cafe.Box[cafe.actualBox].activeInHierarchy)
        {
            PlayerPrefs.SetInt("boxActive", 1);
        }
        else
        {
            PlayerPrefs.SetInt("boxtActive", 0);
        }
        //storing
        PlayerPrefs.SetInt("currentSlots", storing.currentSlots);
        PlayerPrefs.SetInt("currentHat", storing.currentHat);
        for (int i = 0; i < storing.currentSlots; i++)
        {
            if(storing.catSlots[i]!= null)
            {
                PlayerPrefs.SetString("Cat" + i, storing.catSlots[i].GetComponent<CatCaracteristics>().race);
            }
            else
            {
                PlayerPrefs.DeleteKey("Cat" + i);
            }
        }
        //upgrades
        for (int i = 0; i < upgrades.BuyUpgrades.Length; i++)
        {
            if (upgrades.BuyUpgrades[i])
            {
                PlayerPrefs.SetInt("upgrade" + i, 1);
            }
            else
            {
                PlayerPrefs.SetInt("upgrade" + i, 0);
            }
        }

        Debug.Log("Saved");
    }
    void LoadData()
    {
        if (PlayerPrefs.HasKey("currentSlots"))
        {
            //upgrades
            for (int i = 0; i < upgrades.BuyUpgrades.Length; i++)
            {
                if (PlayerPrefs.GetInt("upgrade" + i)==1)
                {
                    upgrades.BuyUpgrades[i] = true;
                
                }
                else
                {
                    upgrades.BuyUpgrades[i] = false;
                }
            }
            //storing
            storing.currentSlots=PlayerPrefs.GetInt("currentSlots");
            storing.currentHat = PlayerPrefs.GetInt("currentHat");
            for (int i = 0; i < storing.currentSlots; i++)
            {
                if(PlayerPrefs.HasKey("Cat" + i))
                {
                    string catRace=PlayerPrefs.GetString("Cat" + i);
                    ramCat.AddACatInPosition(catRace,i);
                }
            }
            if (storing.currentHat != -1)
            {
                storing.UpdateHats(storing.currentHat);
            }
            //Muebles activos
            cafe.actualChair=PlayerPrefs.GetInt("chairInScreen");
            if (PlayerPrefs.GetInt("chairActive")==1)
            {
                cafe.ChangeChair(cafe.actualChair);
            }
            cafe.actualPlant=PlayerPrefs.GetInt("plantScreen", cafe.actualPlant);
            if (PlayerPrefs.GetInt("plantActive", cafe.actualPlant)==1)
            {
                cafe.ChangePlant(cafe.actualPlant);
            }
            cafe.actualToy=PlayerPrefs.GetInt("toyScreen");
            if (PlayerPrefs.GetInt("toyActive")==1)
            {
                cafe.ChangePlant(cafe.actualToy);
            }
            cafe.actualBox=PlayerPrefs.GetInt("boxScreen");
            if (PlayerPrefs.GetInt("boxActive")==1)
            {
                cafe.ChangeBox(cafe.actualBox);
            }
            //tiempo rescate
            if (PlayerPrefs.GetInt("rescuing?") == 1)
            {
                rescue.rescuing1 = true;
            }
            else
            {
                rescue.rescuing1 = false;
            }
            if (PlayerPrefs.GetInt("needToActivateButton") == 1)
            {
                rescue.needToActivateButton = true;
            }
            else
            {
                rescue.needToActivateButton = false;
            }
            rescue.timeToRescue1=PlayerPrefs.GetFloat("rescuingTime");
            rescue.probabilityCatRescue1.x=PlayerPrefs.GetInt("probabilityCatRescue1x");
            rescue.probabilityCatRescue1.y=PlayerPrefs.GetInt("probabilityCatRescue1y");
            rescue.probabilityCatRescue1.z=PlayerPrefs.GetInt("probabilityCatRescue1z");
            //resources
            resources.hairBallsNum=PlayerPrefs.GetInt("hairballs");
            resources.coinsNum = PlayerPrefs.GetInt("coins");
            resources.popularityNum = PlayerPrefs.GetInt("popularity");
        }

        Debug.Log("loaded");
    }
    
}
