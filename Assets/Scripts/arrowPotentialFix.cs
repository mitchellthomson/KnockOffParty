using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class arrowPotentialFix : MonoBehaviour
{
    [SerializeField]
    public List<Transform> starList = new List<Transform>();

    public void Awake()
    {
        int i = 0; 
        int arrowSave = 0;
        starList.Clear();

        while(i<transform.childCount)
        {
            Transform child = transform.GetChild(i);
            if(child.GetComponent<spot>().isArrow==true)
            {
                arrowRouter(child,transform,i+1);
                i++;
                child = transform.GetChild(i);
                i++;
                arrowSave = i;
            }

            print(i);
            print(child);
            print(transform.childCount);

            if(child.GetComponent<spot>().isEndofArrow==true)
            {
                Transform temp = child;
                child=transform.GetChild(arrowSave);
                
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
        Transform spot = routeManager.GetChild(i);
        arrow.GetComponent<arrow>().Leftpath = spot;
        spot = routeManager.GetChild(i+1);
        arrow.GetComponent<arrow>().Rightpath = spot;
    }

    public int nestedArrow(int x)
    {

        return x;
    }
}
