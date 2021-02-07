using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class routeInit : MonoBehaviour
{
    [SerializeField]
    public List<Transform> starList = new List<Transform>();

    private int arrowCounter = 0;

    public void Awake()
    {
        int leftPathCount = transform.parent.childCount-1;
        int i = 0;

        starList.Clear();
        while(i<transform.childCount)
        {
            Transform child = transform.GetChild(i);

            if(child.GetComponent<spot>().isArrow==true)
            {
                arrowRouter(child,transform,i);
                i+=arrowCounter;
                child = transform.GetChild(i);
            }

            if(child.GetComponent<spot>().isStar==true)
            {
                starList.Add(child);
            }
            if(i==transform.childCount-1)
            {
                child.GetComponent<spot>().nextSpot = transform.GetChild(1);
            }
            else
            {
                child.GetComponent<spot>().nextSpot = transform.GetChild(i+1);
            }

            i++;
        }

    }

    public void arrowRouter(Transform arrow,Transform routeManager,int i)
    {
        arrowCounter = 0;
        int counter = i+1;
        Transform spot = routeManager.GetChild(counter);
        Transform endLeftSpot=null;
        Transform endRightSpot=null;
        arrow.GetComponent<arrow>().Leftpath = spot;
        bool check = false;

        while(check==false)
        {
            if(spot.GetComponent<spot>().isStar==true)
                {
                    starList.Add(spot);
                }

            if(spot.GetComponent<spot>().isEndOfArrowLeft==true)
            {
                endLeftSpot = spot;
                arrowCounter++;
                counter++;
                check=true;
            }

            else
            {
                counter++;
                arrowCounter++;
                spot.GetComponent<spot>().nextSpot = routeManager.GetChild(counter);
                spot = routeManager.GetChild(counter);
            }
        }

        spot = routeManager.GetChild(counter);
        arrow.GetComponent<arrow>().Rightpath =spot;
        check = false;

        while(check==false)
        {
            if(spot.GetComponent<spot>().isStar==true)
                {
                    starList.Add(spot);
                }

            if(spot.GetComponent<spot>().isEndOfArrowRight==true)
            {
                endRightSpot = spot;
                arrowCounter++;
                counter++;
                check=true;
            }

            else
            {
                counter++;
                arrowCounter++;
                spot.GetComponent<spot>().nextSpot = routeManager.GetChild(counter);
                spot = routeManager.GetChild(counter);
            }
        }
        endLeftSpot.GetComponent<spot>().nextSpot=routeManager.GetChild(counter);
    }
    

}
