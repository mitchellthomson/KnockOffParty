using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardSpot : MonoBehaviour
{

[SerializeField]
public enum spotColour
{
    none,
    blue,
    red,
    green,
};

[SerializeField]
public spotColour colour;

[SerializeField]
public Transform nextSpot;

[SerializeField]
public int spotChips;

[SerializeField]
public bool isStar;

[SerializeField]
public bool curStar;

void Awake()
{
    Material spotMat = gameObject.GetComponent<Renderer>().material;
    switch (colour)
    {
        case spotColour.blue: 
            spotChips = 15;
            spotMat.color=Color.blue;
            break;
        case spotColour.red:
            spotChips = -15;
            spotMat.color=Color.red;
            break;
        case spotColour.green:
            spotMat.color=Color.green;
            break;
    }
    if(curStar==true)
    {
        spotMat.color=Color.white;
    }
}


}
