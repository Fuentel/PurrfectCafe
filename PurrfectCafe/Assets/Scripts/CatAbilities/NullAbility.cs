using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullAbility : CatAbility
{
    public ManageStoring storing;
    public ResourcesController resources;
    public GameObject[] aux;
    public GameObject generalCanvas;
    public GameObject resourcesCanvas;
    private float timePassed=10.0f;
    private float timeToBonus = 10.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        aux = GameObject.FindGameObjectsWithTag("Resources");
        resourcesCanvas = aux[0];
        resources = resourcesCanvas.GetComponent<ResourcesController>();
        aux = GameObject.FindGameObjectsWithTag("GeneralCanvas");
        generalCanvas = aux[0];
        storing = generalCanvas.GetComponent<ManageStoring>();
    }
    // Start is called before the first frame update
    void Start()
    {

        DescriptionCat = "Null Steve Description";
        DescriptionCatAbility = "Null Steve Ability";
    }
    // Update is called once per frame
    void Update()
    {
        timePassed -= Time.deltaTime;
    }
    public override void AbilityOfTheCat()
    {
        if (resources != null && timePassed <= 0.0f)
        {
            bool check = false;
            for(int i=0;i<8; i++)
            {
                if (storing.catSlots[i] != null)
                {
                    if (storing.catSlots[i].GetComponent<CatCaracteristics>().race == "Null")
                    {
                        check = true;
                        break;
                    }
                }
            }
            if (check)
            {
                resources.GetComponent<ResourcesController>().coinsNum += 100;
                resources.GetComponent<ResourcesController>().hairBallsNum += 100;
                timePassed = timeToBonus;
                //sonido de bug
            }
        }
    }
}
