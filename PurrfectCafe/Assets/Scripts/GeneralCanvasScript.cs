using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCanvasScript : MonoBehaviour
{
    public GameObject Storing;
    public GameObject Nursery;
    public GameObject Shop;
    public ManageStoring storingScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Nursery.activeSelf)
        {
            for (int i = 0; i < storingScript.catSlots.Length; i++)
            {
                if (storingScript.catSlots[i] != null)
                {
                    storingScript.catSlots[i].GetComponent<CatCaracteristics>().ChangeScaleToNursery();
                }
            }
        }
        else if (Storing.activeSelf)
        {
            for (int i = 0; i < storingScript.catSlots.Length; i++)
            {
                if (storingScript.catSlots[i] != null)
                {
                    storingScript.catSlots[i].GetComponent<CatCaracteristics>().ChangeScaleToStoring();
                }
            }
        }
        else if (Shop.activeSelf)
        {

        }
    }
}
