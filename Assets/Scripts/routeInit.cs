using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class routeInit : MonoBehaviour
{
    [SerializeField]
    public List<Transform> starList = new List<Transform>();
    
    [SerializeField]
    private int arrowTrack;

    public void Awake()
    {
        int i = 0;
        arrowTrack = 1;
        starList.Clear();
        while(i<transform.childCount)
        {
            Transform child = transform.GetChild(i);

            if(child.GetComponent<spot>().isArrow==true)
            {
                print(i);
                arrowAssign(child,transform,i);
                i+=arrowTrack;
                print(i);
                child = transform.GetChild(i);
                
            }

            if(child.GetComponent<spot>().isStar==true)
            {
                starList.Add(child);
            }
            
            if(i==transform.childCount-1)
            {
                child.GetComponent<spot>().nextSpot = transform.GetChild(1);
                child.GetComponent<spot>().prevSpot = transform.GetChild(i-1);
                child = transform.GetChild(1);
                child.GetComponent<spot>().prevSpot = transform.GetChild(i);
            }
            else
            {
                child.GetComponent<spot>().nextSpot = transform.GetChild(i+1);
                if(i!=0)
                {
                    child.GetComponent<spot>().prevSpot = transform.GetChild(i-1);
                }
            }
            i++;
        }

    }

    public void arrowAssign(Transform arrow, Transform routeManager, int i)
    {
        int counter = i + 1;
        arrowTrack = 1;
        Transform spot = routeManager.GetChild(counter);
        arrow.GetComponent<arrow>().Leftpath = spot;

        bool check = false;

        while(check==false)
        {
            if(spot.GetComponent<spot>().isStar==true)
            {
                starList.Add(spot);
            }

            if(spot.GetComponent<spot>().isEndofArrow==true)
            {
                counter++;
                spot.GetComponent<spot>().nextSpot = spot.GetComponent<spot>().setSpot;
                spot.GetComponent<spot>().prevSpot = routeManager.GetChild(counter-2);
                spot = routeManager.GetChild(counter);
                check = true;
            }

            arrowTrack++;
            counter++;
            spot.GetComponent<spot>().nextSpot = routeManager.GetChild(counter);
            spot.GetComponent<spot>().prevSpot = routeManager.GetChild(counter-2);
            spot = routeManager.GetChild(counter);
            
        }

        Transform right = routeManager.GetChild(counter-1);
        print(right);
        arrow.GetComponent<arrow>().Rightpath = spot;
        check = false;
        while(check==false)
        {
            if(spot.GetComponent<spot>().isStar==true)
            {
                starList.Add(spot);
            }

            if(spot.GetComponent<spot>().isEndofArrow==true)
            {
                arrowTrack++;
                spot.GetComponent<spot>().nextSpot = spot.GetComponent<spot>().setSpot;
                spot.GetComponent<spot>().prevSpot = routeManager.GetChild(counter-2);
                check = true;
            }

            arrowTrack++;
            counter++;
            spot.GetComponent<spot>().nextSpot = routeManager.GetChild(counter);
            spot.GetComponent<spot>().prevSpot = routeManager.GetChild(counter-2);
            spot = routeManager.GetChild(counter);     
        }
        right.GetComponent<spot>().prevSpot = routeManager.GetChild(i);
    }

}
