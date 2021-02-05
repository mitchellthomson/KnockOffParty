using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotManager : MonoBehaviour
{
    public spot spot;

    public void spots()
    {
        foreach(Transform child in transform)
        {
            spot = child.GetComponent<spot>();
            if (spot.isArrow ==false)
            {
                Material spotMat = spot.gameObject.GetComponent<Renderer>().material;
                switch (spot.colour)
                {
                    case spot.spotColour.blue: 
                        spot.spotChips = 15;
                        spotMat.color=Color.blue;
                        break;
                    case spot.spotColour.red:
                        spot.spotChips = -15;
                        spotMat.color=Color.red;
                        break;
                    case spot.spotColour.green:
                        spotMat.color=Color.green;
                        break;
                }
                if(spot.curStar==true)
                {
                    spotMat.color=Color.white;
                }
            }
        }
    }


}
