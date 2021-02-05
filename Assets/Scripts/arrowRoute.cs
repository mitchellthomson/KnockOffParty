using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowRoute : MonoBehaviour
{
    [SerializeField]
    public GameObject arrow_UI;

    [SerializeField]
    public playerMove playerMove;

    [SerializeField]
    private int returningSpeed;

    [SerializeField]
    private Transform curPlayer;

    [SerializeField]
    private Transform curArrow;

    public void leftPath()
    {
        arrow_UI.SetActive(false);
        curArrow.GetComponent<spot>().nextSpot=curArrow.GetComponent<arrow>().Leftpath;
        StartCoroutine(playerMove.returnFromArrow(returningSpeed,curPlayer,curArrow));
    }

    public void rightPath()
    {
        arrow_UI.SetActive(false);
        curArrow.GetComponent<spot>().nextSpot=curArrow.GetComponent<arrow>().Rightpath;
        StartCoroutine(playerMove.returnFromArrow(returningSpeed,curPlayer,curArrow));
    }

    public void arrowPick(int speed,Transform player,Transform arrow)
    {
        returningSpeed = speed;
        curPlayer = player;
        curArrow = arrow;
        arrow_UI.SetActive(true);
    }
}
