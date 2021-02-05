using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardManager : MonoBehaviour
{
    [SerializeField]
    public routeInit route;

    [SerializeField]
    public int starPosCount = 0;

    [SerializeField]
    public spotManager spotManager;
    
    private List<Transform> starList = new List<Transform>();

    public void refreshStar()
    {
        starList = route.starList;
        starList[starPosCount].GetComponent<spot>().curStar = true;
        spotManager.spots();
    }
}
