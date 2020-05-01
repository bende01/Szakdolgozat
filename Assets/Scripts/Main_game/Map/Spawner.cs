using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{

    public List<GameObject> enemies;
    

    void Start()
    {
        int pick = Random.Range(0, enemies.Count);
        GameObject.Instantiate<GameObject>(enemies[pick],transform.position,transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
