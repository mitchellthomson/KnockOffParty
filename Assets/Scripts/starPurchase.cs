using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starPurchase : MonoBehaviour
{
    [SerializeField]
    public GameObject star_UI;

    [SerializeField]
    public playerMove playerMove;

    [SerializeField]
    public Transform buyingPlayer;

    [SerializeField]
    private int returningSpeed;

    [SerializeField]
    public boardManager boardManager;
    public void acceptStar()
    {
        star_UI.SetActive(false);
        buyingPlayer.GetComponent<playerInfo>().Player_Chips -= 15;
        buyingPlayer.GetComponent<playerInfo>().Player_Stars++;
        boardManager.newStar();
        StartCoroutine(playerMove.returnFromShop(returningSpeed,buyingPlayer));
    }

    public void denyStar()
    {
        star_UI.SetActive(false);
        StartCoroutine(playerMove.returnFromShop(returningSpeed,buyingPlayer));
    }

    public void starSpot(int speed, Transform player)
    {
        returningSpeed = speed;
        buyingPlayer = player;

        int chips = player.GetComponent<playerInfo>().Player_Chips;
        Text infoText = star_UI.transform.GetChild(0).GetComponent<Text>();
        Button confirmBut = star_UI.transform.GetChild(1).GetComponent<Button>();
        Button denyBut = star_UI.transform.GetChild(2).GetComponent<Button>();
        

        if(chips>=15)
        {
            star_UI.SetActive(true);
            confirmBut.gameObject.SetActive(true);
            confirmBut.enabled = true;
            denyBut.enabled = true;
            infoText.text = "You can buy a star, it costs 15 chips";
            confirmBut.GetComponentInChildren<Text>().text = "Accept";
            denyBut.GetComponentInChildren<Text>().text = "Deny";
        }
        else
        {
            star_UI.SetActive(true);
            denyBut.enabled = true;
            confirmBut.gameObject.SetActive(false);
            infoText.text = "fuck off";
            denyBut.GetComponentInChildren<Text>().text = "Okay";
        }
    }
}
