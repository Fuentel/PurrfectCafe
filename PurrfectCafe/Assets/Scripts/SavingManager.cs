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
        LoadData();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        //resources
        PlayerPrefs.SetInt("hairballs", resources.hairBallsNum);
        PlayerPrefs.SetInt("coins", resources.coinsNum);
        PlayerPrefs.SetInt("popularity", resources.popularityNum);
        //tiempo rescate
        PlayerPrefs.SetFloat("rescuingTime", rescue.timeToRescue1);
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
        PlayerPrefs.GetInt("currentSlots", storing.currentSlots);
        for (int i = 0; i < storing.currentSlots; i++)
        {
            PlayerPrefs.GetString("Cat" + i, storing.catSlots[i].GetComponent<CatCaracteristics>().race);
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
    }
    void LoadData()
    {
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
        //storing
        PlayerPrefs.GetInt("currentSlots", storing.currentSlots);
        for (int i = 0; i < storing.currentSlots; i++)
        {
            PlayerPrefs.GetString("Cat" + i, storing.catSlots[i].GetComponent<CatCaracteristics>().race);
        }
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
        //tiempo rescate
        PlayerPrefs.SetFloat("rescuingTime", rescue.timeToRescue1);

        //resources
        PlayerPrefs.SetInt("hairballs", resources.hairBallsNum);
        PlayerPrefs.SetInt("coins", resources.coinsNum);
        PlayerPrefs.SetInt("popularity", resources.popularityNum);
    }
    
}
