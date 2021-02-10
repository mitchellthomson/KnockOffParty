using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class routingTest : MonoBehaviour
{
    [SerializeField]
    public List<Transform> starList = new List<Transform>();

    [SerializeField]
    private int tracker;

    public void Awake()
    {
        int leftPathCount = transform.parent.childCount-1;
        int i = 0; 
        tracker=1;

        starList.Clear();
        while(i<transform.childCount)
        {
            Transform child = transform.GetChild(i);

            if(child.GetComponent<spot>().isArrow==true)
            {
                tracker++;
                arrowRouter(child,transform,i);
                i+=tracker;
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
            tracker++;
        }

    }

    public void arrowRouter(Transform arrow,Transform routeManager,int i)
    {
        int tracker = i+1;
        Transform spot = routeManager.GetChild(tracker);
        Transform endLeftSpot=null;
        Transform endRightSpot=null;

        arrow.GetComponent<arrow>().Leftpath = spot;
        bool check = false;
        while(check==false)
        {
            if(spot.GetComponent<spot>().isArrow==true)
            {
                arrowRouter(spot,routeManager,tracker);
                spot = routeManager.GetChild(tracker+1);
                
            }

            if(spot.GetComponent<spot>().isStar==true)
            {
                starList.Add(spot);
            }
            
            if(spot.GetComponent<spot>().isEndofArrow==true)
            {
                endLeftSpot = spot;
                check=true;
                tracker++;
                spot = routeManager.GetChild(tracker);
                
            }

            else
            {
                tracker++;
                spot.GetComponent<spot>().nextSpot = routeManager.GetChild(tracker);
                spot = routeManager.GetChild(tracker);
            }

        }
        arrow.GetComponent<arrow>().Rightpath =spot;
        check = false;

        while(check==false)
        {
            if(spot.GetComponent<spot>().isStar==true)
            {
                starList.Add(spot);
            }

            if(spot.GetComponent<spot>().isEndofArrow==true)
            {
                endRightSpot=spot;
                check=true;
                
                spot = routeManager.GetChild(tracker);
                tracker++;
            }
            else
            {
                
                spot.GetComponent<spot>().nextSpot = routeManager.GetChild(tracker);
                spot = routeManager.GetChild(tracker);
                tracker++;
            }
        }
        endLeftSpot.GetComponent<spot>().nextSpot = routeManager.GetChild(tracker);
        endRightSpot.GetComponent<spot>().nextSpot = routeManager.GetChild(tracker);
        print("tracker"+tracker);
    }
    

}
