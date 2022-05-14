using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesHandeling : MonoBehaviour
{
    public bool[] BuyUpgrades = new bool[24];
    public bool[] AlreadyDoneUpgrades = new bool[24];
    public Vector2Int[] UpgradesCost = new Vector2Int[24];
    public GameObject NotEnough;
    public CatSpaceController catSpace;
    public ResourcesController resources;
    public CafeController cafe;
    public ManageStoring storing;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i< BuyUpgrades.Length; i++)
        {
            BuyUpgrades[i] = false;
        }
        for (int i=0; i< AlreadyDoneUpgrades.Length; i++)
        {
            AlreadyDoneUpgrades[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpgradesFatFunction();
    }
    public void ActivateUpgrade(int toActivate)
    {
        if (resources.hairBallsNum < UpgradesCost[toActivate].x || resources.coinsNum < UpgradesCost[toActivate].y)
        {
            resources.hairBallsNum -= UpgradesCost[toActivate].x;
            resources.coinsNum -= UpgradesCost[toActivate].y;
            BuyUpgrades[toActivate] = true;
        }
        else
        {
            NotEnough.SetActive(true);
        }
    }
    public void NotEnought()
    {
        NotEnough.SetActive(false);
    }
    void UpgradesFatFunction()
    {
        for(int i=0; i < BuyUpgrades.Length; i++)
        {
            if (BuyUpgrades[i] && !AlreadyDoneUpgrades[i])
            {
                AlreadyDoneUpgrades[i] = true;
               
                if (i < 3)
                {
                    UpgradeMoreHairballsPerClickMain(0.05f + 0.05f * i);
                }
                else if (i < 6)
                {
                    UpgradeMoreHairballsPerClick(0.05f + 0.05f * (i - 3));
                }
                else if (i < 7)
                {
                    UpgradeMoreHairballsPerClickSupp(0.15f + 0.05f * (i - 6));
                }
                else if (i < 11)
                {
                    UpgradeCatPopularity(0.05f + 0.05f * (i - 8));
                }
                else if (i < 14)
                {
                    UpgradeFurniturePopularity(0.05f + 0.05f * (i - 11));
                }
                else if (i < 16)
                {
                    UpgradeMoreCoins(0.05f + 0.05f * (i - 14));
                }
                else if (i == 16)
                {
                    cafe.ChangePlant(0);
                }
                else if (i == 17)
                {
                    cafe.ChangeToy(0);
                }
                else if (i == 18)
                {
                    cafe.ChangeChair(1);
                }
                else if (i == 19)
                {
                    cafe.ChangeBox(1);
                }
                else if (i == 20)
                {
                    cafe.ChangeChair(2);
                }
                else if (i == 21)
                {
                    storing.currentSlots += 9;
                }
                else if (i == 22)
                {
                    storing.currentSlots += 9;
                }
                else if (i == 22)
                {
                    UpgradeMoreCoins(0.20f);
                    UpgradeMoreHairballsPerClick(0.20f);
                }
            }
        }
    }
    void UpgradeMoreHairballsPerClick(float sum)
    {
        catSpace.upgradeMultiplier += sum;
    }
    void UpgradeMoreHairballsPerClickMain(float sum)
    {
        catSpace.upgradeMainMultiplier += sum;
    }
    void UpgradeMoreHairballsPerClickSupp(float sum)
    {
        catSpace.upgradeSuppMultiplier += sum;
    }
    void UpgradeMoreCoins(float sum)
    {
        cafe.upgradeCoins += sum;
    }
    void UpgradeCatPopularity(float sum)
    {
        cafe.upgradeCoins += sum;
    }
    void UpgradeFurniturePopularity(float sum)
    {
        cafe.upgradeCoins += sum;
    }
    void UpgradeSlots()
    {
        storing.currentSlots += 9;
    }
    
}
