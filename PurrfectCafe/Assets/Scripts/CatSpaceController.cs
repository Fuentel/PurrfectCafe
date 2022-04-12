using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpaceController : MonoBehaviour
{
    public ResourcesController resources;
    public ManageCatPosition catPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GenerateHairballs()
    {
        resources.changeHairBalls(catPosition.currentMainCat.GetComponent<CatCaracteristics>().HairBallPerClick);
        if (catPosition.catSupp1 != null)
        {
            resources.changeHairBalls(catPosition.catSupp1.GetComponent<CatCaracteristics>().HairBallPerClickSupp);
        }
        if (catPosition.catSupp2 != null)
        {
            resources.changeHairBalls(catPosition.catSupp2.GetComponent<CatCaracteristics>().HairBallPerClickSupp);
        }
        if (catPosition.catSupp3 != null)
        {
            resources.changeHairBalls(catPosition.catSupp3.GetComponent<CatCaracteristics>().HairBallPerClickSupp);

        }
        if (catPosition.catSupp4 != null)
        {
            resources.changeHairBalls(catPosition.catSupp4.GetComponent<CatCaracteristics>().HairBallPerClickSupp);

        }
    }
}
