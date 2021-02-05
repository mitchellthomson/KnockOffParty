using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineDraw : MonoBehaviour
{
    void OnDrawGizmos() 
    {
        //Draws lines bettween points on individual routes
        int i =0;
        while(i<transform.childCount)
        {
            Gizmos.color=Color.cyan;
            Transform routeToDraw = transform.GetChild(i);

            if(routeToDraw.GetComponent<spot>().isArrow)
            {
                Gizmos.color=Color.red;
                Vector3 curArrow = routeToDraw.position;
                Vector3 leftDraw = routeToDraw.GetComponent<arrow>().Leftpath.position;
                Vector3 rightDraw = routeToDraw.GetComponent<arrow>().Rightpath.position;
                Gizmos.DrawLine(curArrow,leftDraw);
                Gizmos.color=Color.magenta;
                Gizmos.DrawLine(curArrow,rightDraw);

                for(int j=0;j<2;j++)
                {
                    Gizmos.color=Color.cyan;
                    Transform arrowPath = routeToDraw.GetChild(j);
                    
                    for(int k=0; k<arrowPath.childCount; k++)
                    {
                        Transform pathSpot = arrowPath.GetChild(k);
                        Vector3 cur = pathSpot.position;
                        Vector3 toDraw = pathSpot.GetComponent<spot>().nextSpot.position;

                        Gizmos.DrawLine(cur,toDraw);
                    }
                }
            }
            else
            {
            Vector3 toDraw = routeToDraw.GetComponent<spot>().nextSpot.position;
            Vector3 cur = routeToDraw.position;
            Gizmos.DrawLine(cur,toDraw);
            }
            i++;
        }
        
    }
}
