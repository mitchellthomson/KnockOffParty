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
    public Transform[] fixedSpots;

    [SerializeField]
    public Transform fixedTop;

    [SerializeField]
    public Transform fixedRightEntrance;

    [SerializeField]
    public Transform fixedBotRightEntrance;

    [SerializeField]
    public Transform fixedLeftEntrance;

    [SerializeField]
    public Transform fixedRightExit;

    [SerializeField]
    public Transform fixedBotRightExit;

    [SerializeField]
    public Transform fixedBotLeftExit;

    [SerializeField]
    public Transform fixedLeftExit;


    void Awake() 
    {
        spinnerSpots.Clear();
        fixedSpots = new Transform[]{fixedTop,fixedRightEntrance,fixedBotRightEntrance,fixedLeftEntrance,fixedRightExit,fixedBotRightExit,fixedBotLeftExit,fixedLeftExit};
        foreach(Transform child in route)
        {
            if(child.GetComponent(typeof(RouletteSpot))!=null)
            {
                spinnerSpots.Add(child);
            }
        }
    }
}
