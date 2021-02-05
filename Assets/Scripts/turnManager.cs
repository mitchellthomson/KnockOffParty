using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnManager : MonoBehaviour
{
    [SerializeField]
    public diceManager dice;
    [SerializeField]
    public gameManage gameManager;
    [SerializeField]
    public playerMove playerMove;
    [SerializeField]
    public int speed;
    [SerializeField]
    private int activePlayer;

    public void startTurn()
    {
        if(activePlayer == 4)
        {
            print("turn over");
            activePlayer=0;
            
        }
        print("Player "+ (activePlayer+1) +"'s Turn!");

        StartCoroutine(takeTurn());
    }

    public IEnumerator takeTurn()
    {
        yield return dice.turnRoll(KeyCode.Space);
        speed = dice.rolled;
        gameManager.SetUI("You Rolled: " + speed);
        playerMove.StartMove(speed,activePlayer);
    }

    public void EndTurn(int chips)
    {
        int playerChips = playerMove.transform.GetChild(activePlayer).GetComponent<playerInfo>().Player_Chips;
        
        if((playerChips + chips)<0)
        {
            playerChips = 0;
        }
        else
        {
            playerChips += chips;
        }
        playerMove.transform.GetChild(activePlayer).GetComponent<playerInfo>().Player_Chips = playerChips;
        gameManager.PlayerUI(activePlayer,playerChips);
        activePlayer++;
        startTurn();
    }
}
