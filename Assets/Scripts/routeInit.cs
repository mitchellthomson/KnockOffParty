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
        int leftPathCount = transform.parent.childCount-1;
        int leftCounter = 1;
        int i = 0;
        while(i<transform.childCount)
        {
            Transform child = transform.GetChild(i);
            if(child.GetComponent<spot>().isArrow==true)
            {
                child.GetComponent<arrow>().Rightpath=transform.GetChild(i+1);

                for(int j = 0;j<child.childCount-1;j++)
                {
                    Transform rightChild = child.GetChild(j);
                    rightChild.GetComponent<spot>().nextSpot = child.GetChild(j+1);
                }

                child.GetComponent<arrow>().Leftpath=transform.parent.GetChild(leftCounter).GetChild(0);
                for(int x = 0;x<transform.parent.GetChild(leftCounter).childCount-1;x++)
                {
                    Transform leftChild = transform.parent.GetChild(leftCounter).GetChild(x);
                    print(leftChild);
                    leftChild.GetComponent<spot>().nextSpot = transform.parent.GetChild(leftCounter).GetChild(x+1);
                }
                leftCounter++;
            }
            else
            {
                if(child.GetComponent<spot>().isStar==true)
                {
                    starList.Add(child);
                }
                if(i==transform.childCount-1)
                {
                    child.GetComponent<spot>().nextSpot = transform.GetChild(1);
                }
                else
                {
                    child.GetComponent<spot>().nextSpot = transform.GetChild(i+1);
                }
                
            }

            i++;
        }

    }


}
