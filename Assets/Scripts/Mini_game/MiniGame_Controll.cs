using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame_Controll : MonoBehaviour
{
    
    public float attackFrequency = 2;
    public float boundarySize_X = 6.0f;
    public float boundarySize_Y = 5.0f;

    public GameObject enemyPrefab;
    public GameObject enemyContainer;
    public Mini_Player player;
    public GameObject tripleOrb;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("PlayerMini").GetComponent<Mini_Player>();
        InvokeRepeating("SpawnEnemy", attackFrequency, attackFrequency);
        InvokeRepeating("SpawnPowerUp", attackFrequency, attackFrequency);


    }

    // Update is called once per frame
    void Update()
    {
        if (player.Dead())
        {
            CancelInvoke("SpawnEnemy");
        }
        else
        {
           // SceneManager.LoadScene("MainMenu");

        }
    }

    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-boundarySize_X, boundarySize_X), boundarySize_Y + 1, 0), Quaternion.identity);
        newEnemy.transform.SetParent(enemyContainer.transform);
    }

    private void SpawnPowerUp()
    {
        GameObject newOrb = Instantiate(tripleOrb, new Vector3(Random.Range(-boundarySize_X, boundarySize_X), boundarySize_Y + 1, 0), Quaternion.identity);
        newOrb.transform.SetParent(enemyContainer.transform);
    }

    

}
