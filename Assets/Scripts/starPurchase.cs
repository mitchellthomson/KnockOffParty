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

    public IEnumerator pickOption(KeyCode key)
    {
        bool hasPressed = false;
        while(!hasPressed)
        {
            if(Input.GetKeyDown(key))
            {
                print("We Rolling");
                hasPressed = true;
                
                yield return hasPressed;

            }
            yield return null;
        }
    }

    public void starSpot(int speed, Transform player)
    {
        int chips = player.GetComponent<playerInfo>().Player_Chips;
        Text infoText = star_UI.transform.GetChild(0).GetComponent<Text>();
        Button confirmBut = star_UI.transform.GetChild(1).GetComponent<Button>();
        Button denyBut = star_UI.transform.GetChild(2).GetComponent<Button>();

        if(chips>=15)
        {
            star_UI.SetActive(true);
            infoText.text = "You can buy a star, it costs 15 chips";
            confirmBut.GetComponentInChildren<Text>().text = "Accept";
            denyBut.GetComponentInChildren<Text>().text = "Deny";
        }
        else
        {
            confirmBut.enabled = false;
            star_UI.SetActive(true);
            infoText.text = "fuck off";
            denyBut.GetComponentInChildren<Text>().text = "Okay";
        }
    }
}
