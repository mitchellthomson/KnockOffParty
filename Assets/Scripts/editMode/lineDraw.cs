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
                Gizmos.color=Color.blue;
                Vector3 curArrow = routeToDraw.position;
                Vector3 leftDraw = routeToDraw.GetComponent<arrow>().Leftpath.position;
                Vector3 rightDraw = routeToDraw.GetComponent<arrow>().Rightpath.position;
                leftDraw.x = leftDraw.x-.05f;
                leftDraw.z = leftDraw.z-.05f;
                rightDraw.x = rightDraw.x-.05f;
                rightDraw.z = rightDraw.z-.05f;
                
                Gizmos.DrawLine(curArrow,leftDraw);
                Gizmos.color=Color.red;
                Gizmos.DrawLine(curArrow,rightDraw);

                i++;
                routeToDraw = transform.GetChild(i);
                Gizmos.color=Color.cyan;
            }
            
            Vector3 toDraw = routeToDraw.GetComponent<spot>().nextSpot.position;
            Vector3 cur = routeToDraw.position;
            Vector3 prev = routeToDraw.GetComponent<spot>().prevSpot.position;
            Gizmos.DrawLine(cur,toDraw);

            if(i!=0)
            {
                cur.x = cur.x+.05f;
                cur.z = cur.z+.05f;
                prev.x = prev.x+.05f;
                prev.z = prev.z+.05f;
                
                Gizmos.color=Color.green;
                Gizmos.DrawLine(cur,prev);
            }
            i++;
        }
        
    }
}
