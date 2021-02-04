using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceManager : MonoBehaviour
{
    public int rolled;

    public IEnumerator turnRoll(KeyCode key)
{
    bool hasRolled = false;
    while(!hasRolled)
    {
        if(Input.GetKeyDown(key))
        {
            print("We Rolling");
            hasRolled = true;
            rolled = Random.Range(1,11);
            
            yield return rolled;

        }
        yield return null;
    }
}
}