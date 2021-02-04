using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class routeInit : MonoBehaviour
{
    [SerializeField]
    public List<Transform> starList = new List<Transform>();
    public void Awake()
    {
        starList.Clear();
        int i = 0;
        while(i<transform.childCount)
        {
            Transform child = transform.GetChild(i);
            if(child.GetComponent<boardSpot>().isStar==true)
            {
                starList.Add(child);
            }
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
