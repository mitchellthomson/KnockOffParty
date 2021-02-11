using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spot : MonoBehaviour
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
    public Transform prevSpot;

    [SerializeField]
    public Transform setSpot;

    [SerializeField]
    public int spotChips;

    [SerializeField]
    public bool isStar;

    [SerializeField]
    public bool curStar;

    [SerializeField]
    public bool isArrow = false;

    [SerializeField]
    public bool isEndofArrow = false;

}
