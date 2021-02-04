using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class routeInit : MonoBehaviour
{

public void Awake()
{
    int i = 0;
    while(i<transform.childCount)
    {
        Transform child = transform.GetChild(i);
        if(i==transform.childCount-1)
        {
            child.GetComponent<boardSpot>().nextSpot = transform.GetChild(1);
        }
        else
        {
            child.GetComponent<boardSpot>().nextSpot = transform.GetChild(i+1);
        }
        
        i++;
    }
}


}
