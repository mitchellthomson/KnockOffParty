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

    [SerializeField]
    private List<Transform> starList = new List<Transform>();

    public void refreshStar()
    {
        if(starList.Count>0)
        {
            starList[starPosCount].GetComponent<spot>().curStar = true;
            spotManager.spots();
            print(starList.Count);
        }
    }

    public void randomizeStar(int i)
    {
        starList = route.starList;
        while(i<starList.Count)
        {
            Transform temp = starList[i];
            int randomIndex = Random.Range(i, starList.Count);
            starList[i] = starList[randomIndex];
            starList[randomIndex] = temp;
            i++;
        }
    }

    public void newStar()
    {
        starList[starPosCount].GetComponent<spot>().curStar = false;
        starPosCount++;
        print("Star pos count = " + starPosCount);
        if(starPosCount==starList.Count)
        {
            Transform temp = starList[starPosCount-1];
            starList.RemoveAt(starPosCount-1);
            randomizeStar(0);
            starList.Add(temp);
            randomizeStar(1);
            starPosCount = 0;
        }
        refreshStar();
    }
}
