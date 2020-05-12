using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    Player player;
    Image  health;
    public Image bossHealth;
    Boss_Behaviour boss;

    bool bossLevel = false;
    void Start()
    {
        if (GameObject.Find("Boss") != null)
        {
            boss = GameObject.Find("Boss").GetComponent<Boss_Behaviour>();
            bossHealth.gameObject.SetActive(true);
            bossLevel = true;
        }
       
        health = gameObject.GetComponent<Image>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = player.health / player.maxHealth;
        if (bossLevel) { bossHealth.fillAmount = boss.currentHealth / boss.health; }
        
    }
}
