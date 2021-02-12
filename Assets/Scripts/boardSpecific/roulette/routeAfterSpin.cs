using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class routeAfterSpin : MonoBehaviour
{
    [SerializeField]
    public spinInit spinInit;

    [SerializeField]
    public spinTheWheel spinTheWheel;

    public void setNewRoute()
    {
        List<Transform> insideExits = spinInit.insideExits;
        List<Transform> wheelExits = spinInit.wheelExits;
        List<Vector3> wheelExitspos = spinInit.wheelExitspos;

        
    }
}
