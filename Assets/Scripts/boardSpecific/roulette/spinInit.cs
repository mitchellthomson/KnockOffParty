using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class spinInit : MonoBehaviour
{
    [SerializeField]
    public Transform route;

    [SerializeField]
    public List<Transform> spinnerSpots = new List<Transform>();

    void Awake() 
    {
        spinnerSpots.Clear();

        foreach(Transform child in route)
        {
            if(child.GetComponent(typeof(RouletteSpot))!=null)
            {
                spinnerSpots.Add(child);
            }
        }
    }
}
