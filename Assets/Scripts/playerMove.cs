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
            nextSpot = curSpot.GetComponent<boardSpot>().nextSpot;

            nextPos = nextSpot.position;
            
            while(MoveToNextNode(nextPos,player)){yield return null;}


            if(curSpot.GetComponent<boardSpot>().curStar == true)
            {
                print("Its a star");
            }
            else
            {
                speed--;
            }
            player.GetComponent<playerInfo>().Player_Cur_Pos = nextSpot;
            yield return new WaitForSeconds(0.1f);
        }
        curSpot = nextSpot;
        nextSpot = curSpot.GetComponent<boardSpot>().nextSpot;
        yield return new WaitForSeconds(1f);
        
        int chips = curSpot.GetComponent<boardSpot>().spotChips;
        Endmove(chips);
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
