using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineDraw : MonoBehaviour
{
    public boardSpot boardSpot;
    void OnDrawGizmos() 
    {

        //Draws lines bettween points on individual routes
        Gizmos.color = Color.red;

        Transform routeToDraw = transform.GetChild(0);

        foreach(Transform child in routeToDraw)
        {
            Vector3 toDraw = child.GetComponent<boardSpot>().nextSpot.position;
            Vector3 cur = child.position;
            Gizmos.DrawLine(cur,toDraw);
        }
    }
}
