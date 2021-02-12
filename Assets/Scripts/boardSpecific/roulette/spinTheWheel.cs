using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinTheWheel : MonoBehaviour
{
    [SerializeField]
    private spinInit spinInit;

    [SerializeField]
    private List<Transform> spinnerSpots = new List<Transform>();

    [SerializeField]
    private Transform topLeftExit;

    [SerializeField]
    private Transform botLeftExit;

    [SerializeField]
    private Transform topExit;

    [SerializeField]
    private Transform topRightExit;

    [SerializeField]
    private Transform botRightExit;

    [SerializeField]
    private Transform leftEntrance;

    [SerializeField]
    private Transform rightEntrance;

    [SerializeField]
    private Transform botEntrance;

    private bool isSpinning;

    private bool isChanging;

    public void spinThatWheel()
    {
        
        spinnerSpots = spinInit.spinnerSpots;
        Vector3 rotateSpot = spinnerSpots[0].GetComponent<RouletteSpot>().SpinSpot.position;
        float time = Random.Range(4f,6f);
        float speed = Random.Range(6f,10f);
        StartCoroutine(spin(rotateSpot,time,speed));
        
    }

    /*public IEnumerator changeRoute()
    {
        float distance = Mathf.Infinity;
        isChanging = false;
        if(isChanging)
        {
            yield break;
        }

        isChanging=true;

        for(int i =0;i<spinnerSpots.Count;i++)
        {
            Vector3 spotPos = spinnerSpots[i].position;
            float spotDis = Vector3.Distance(entrancePos, spotPos);
            if(spotDis<distance)
            {
                outOfSpin = spinnerSpots[i];
                distance = spotDis;
            }
        }
        yield return new WaitForSeconds(0.5f);

    }
    */

    public IEnumerator spin(Vector3 rotateSpot,float time,float speed)
    {
        if(isSpinning)yield break;
        List<Transform> spinnerSpots = spinInit.spinnerSpots;

        speed = 1f;
        var passedTime = 0f;

        while(passedTime < time)
        {
            var lerpFactor = passedTime / time;
            passedTime += Mathf.Min(time - passedTime, Time.deltaTime);
            foreach(Transform child in spinnerSpots)
            {
                child.RotateAround(rotateSpot,Vector3.up,speed);
            }
            
            yield return null;
        }
        
        isSpinning = false;
        //StartCoroutine(changeRoute());
    }

}
