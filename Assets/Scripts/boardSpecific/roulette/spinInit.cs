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

    [SerializeField]
    public List<Transform>insideExits = new List<Transform>();

    [SerializeField]
    public List<Transform>wheelExits = new List<Transform>();

    [SerializeField]
    public List<Vector3>wheelExitspos = new List<Vector3>();

    void Awake() 
    {
        wheelExitspos.Clear();
        spinnerSpots.Clear();
        foreach(Transform child in route)
        {
            if(child.GetComponent(typeof(RouletteSpot))!=null)
            {
                spinnerSpots.Add(child);
            }
        }
        foreach(Transform child in wheelExits)
        {
            wheelExitspos.Add(child.position);
        }
    }
}
