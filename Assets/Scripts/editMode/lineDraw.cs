using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineDraw : MonoBehaviour
{
    void OnDrawGizmos() 
    {
        Gizmos.color=Color.cyan;
        //Draws lines bettween points on individual routes
        int i =0;
        while(i<transform.childCount)
        {
            Transform routeToDraw = transform.GetChild(i);
            Vector3 toDraw = routeToDraw.GetComponent<boardSpot>().nextSpot.position;
            Vector3 cur = routeToDraw.position;
            Gizmos.DrawLine(cur,toDraw);
            i++;
        }
        
    }
}
