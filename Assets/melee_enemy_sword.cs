﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_enemy_sword : MonoBehaviour
{
    public float damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player") { collision.GetComponent<Player>().GetDamage(damage); }
        
    }
}
