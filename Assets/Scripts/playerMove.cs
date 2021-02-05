using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    int routePos;

    bool isMoving;
    [SerializeField]
    private Transform curSpot;

    [SerializeField]
    private Transform nextSpot;

    [SerializeField]
    private Vector3 nextPos;

    [SerializeField]
    public Transform activePlayer;

    [SerializeField]
    public turnManager turnManager;

    [SerializeField]
    public starPurchase starPurchase;

    public void StartMove(int speed, int playerNumber)
    {
        Transform player = transform.GetChild(playerNumber);
        StopCoroutine(Move(speed,player));
        StartCoroutine(Move(speed,player));
        
        activePlayer = player;
    }

    public IEnumerator Move(int speed,Transform player)
    {
        isMoving = false;
        if(isMoving)
        {
            yield break;
        }

        isMoving=true;
        
        while(speed>0)
        {
            curSpot = player.GetComponent<playerInfo>().Player_Cur_Pos;
            nextSpot = curSpot.GetComponent<spot>().nextSpot;

            nextPos = nextSpot.position;
            
            while(MoveToNextNode(nextPos,player)){yield return null;}

            if(nextSpot.GetComponent<spot>().curStar == true)
            {
                print("Its a star");
                curSpot = nextSpot;
                nextSpot = curSpot.GetComponent<spot>().nextSpot;
                nextPos = nextSpot.position;
                StopAllCoroutines();
                starPurchase.starSpot(speed,player);

            }
            else
            {
                speed--;
            }
            player.GetComponent<playerInfo>().Player_Cur_Pos = nextSpot;
            yield return new WaitForSeconds(0.05f);
        }
        curSpot = nextSpot;
        nextSpot = curSpot.GetComponent<spot>().nextSpot;
        
        int chips = curSpot.GetComponent<spot>().spotChips;
        Endmove(chips);
    }

    public IEnumerator returnFromShop(int speed,Transform player)
    {
        while(MoveToNextNode(nextPos,player)){yield return null;}
        speed--;
        StartCoroutine(Move(speed,player));
    }
    bool MoveToNextNode(Vector3 goal,Transform player)
    {
        return goal !=(player.position = Vector3.MoveTowards(player.position,goal,2f* Time.deltaTime));
    }

    public void Endmove(int chips)
    {
        print("Ended");
        turnManager.EndTurn(chips);
    }
}
