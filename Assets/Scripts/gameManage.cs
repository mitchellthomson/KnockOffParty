using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManage : MonoBehaviour
{
    [SerializeField]
    public int turns = 10;
    
    [SerializeField]
    public Transform players;

    [SerializeField]
    public turnManager turnManager;

    [SerializeField]
    public Text UI;

    [SerializeField]
    public Text[] player_UI;
    

    void Start() 
    {
        UI.text="Welcome";
        gameStarted();
    }

    public void gameStarted()
    {
        Color[]playerColors = {Color.red,Color.blue,Color.yellow,Color.green};
        int i =0;
        foreach(Transform child in players)
        {
            Material spotMat = child.GetComponent<Renderer>().material;
            spotMat.color=playerColors[i];
            i++;
        }
        playGame();
    }

    public void playGame()
    {
        turnManager.startTurn();
    }

    public void SetUI(string entry)
    {
        UI.text = entry;
    }

    public void PlayerUI(int player,int playerChips)
    {
        Text ui = player_UI[player];
        Transform activePlayer = players.GetChild(player);
        ui.text = "Player"+(player+1)+"Chips: "+(playerChips)  + "Stars: "+activePlayer.GetComponent<playerInfo>().Player_Stars;
    }
}
