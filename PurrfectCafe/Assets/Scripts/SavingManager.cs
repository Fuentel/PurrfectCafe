using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingManager : MonoBehaviour
{
    public ResourcesController resources;
    public ManageStoring storing;
    public RescueCat rescue;
    public CafeController cafe;
    public UpgradesHandeling Upgrades;
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

    }
    void LoadData()
    {

    }
    
}
