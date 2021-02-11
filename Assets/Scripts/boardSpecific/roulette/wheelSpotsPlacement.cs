using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelSpotsPlacement : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPefab;

    [SerializeField]
    public List<Transform> rouletteSpots = new List<Transform>();

    [SerializeField]
    public List<Transform> genSpots = new List<Transform>();

    public void Start()
    {
        CreateEnemiesAroundPoint (38,transform.position,20f);
        PermCircle();
    }
    public void CreateEnemiesAroundPoint (int num, Vector3 point, float radius)
    {
        
        for (int i = 0; i < num; i++)
        {
            
            /* Distance around the circle */  
            var radians = 2 * Mathf.PI / num * i;
            
            /* Get the vector direction */ 
            var vertrical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians); 
            
            var spawnDir = new Vector3 (horizontal, 0, vertrical);
            
            /* Get the spawn position */ 
            var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point
            
            /* Now spawn */
            var enemy = Instantiate (enemyPefab, spawnPos, Quaternion.identity) as GameObject;
            
            /* Rotate the enemy to face towards player */
            enemy.transform.LookAt(point);
            
            /* Adjust height */
            enemy.transform.Translate (new Vector3 (0, enemy.transform.localScale.y / 2, 0));
            
            genSpots.Add(enemy.transform);
        }
    }

    public void PermCircle()
    {
        foreach(Transform child in transform)
        {
            rouletteSpots.Add(child);
        }

        for(int i =0;i<rouletteSpots.Count-1;i++)
        {
            rouletteSpots[i].position = genSpots[i].position;
            rouletteSpots[i].gameObject.name = "Roulette Spot("+(i+1)+")";
            rouletteSpots[i].GetComponent<RouletteSpot>().SpinSpot=transform;
        }
    }    
}



