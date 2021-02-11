using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinTheWheel : MonoBehaviour
{
    [SerializeField]
    public spinInit spinInit;

    [SerializeField]
    public GameObject bottomEntrance;

    [SerializeField]
    public GameObject bottomExit;

    [SerializeField]
    public Transform intoSpin;

    [SerializeField]
    public Transform outOfSpin;

    [SerializeField]
    public List<Transform> spinnerSpots = new List<Transform>();

    private bool isSpinning;

    private bool isChanging;

    public void spinThatWheel()
    {
        
        spinnerSpots = spinInit.spinnerSpots;
        Vector3 rotateSpot = spinnerSpots[0].GetComponent<RouletteSpot>().SpinSpot.position;
        Vector3 entrancePos = bottomEntrance.transform.position;
        float time = Random.Range(4f,6f);
        float speed = Random.Range(6f,10f);
        StartCoroutine(spin(rotateSpot,time,speed));
        
    }

    public IEnumerator changeRoute()
    {
        Vector3 entrancePos = bottomEntrance.transform.position;
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
        intoSpin.GetComponent<spot>().nextSpot = outOfSpin;

    }

    public IEnumerator spin(Vector3 rotateSpot,float time,float speed)
    {
        if(isSpinning)yield break;
        List<Transform> spinnerSpots = spinInit.spinnerSpots;

        var passedTime = 0f;

        while(passedTime < time)
        {
            var lerpFactor = passedTime / time;
            passedTime += Mathf.Min(time - passedTime, Time.deltaTime);
            foreach(Transform child in spinnerSpots)
            {
                child.RotateAround(rotateSpot,Vector3.down,speed);
            }
            
            yield return null;
        }
        
        isSpinning = false;
        StartCoroutine(changeRoute());
    }

}
