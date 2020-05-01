﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 20;
    private GameObject map;

    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
        map = GameObject.Find("Tilemap");
    }

    private void Update()
    {
        OutOfBounds();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Enemy" && this.tag == "Player")
        {
            collision.GetComponent<SimpleEnemy>().GetDamage(damage);
            Destroy(gameObject);
        }


        if (collision.tag == "Player" && this.tag == "Enemy")
        {
            collision.GetComponent<Player>().GetDamage(damage);
            Destroy(gameObject);
        }

       

    }

    private void OutOfBounds()
    {
        if (gameObject.transform.position.x < -15 || gameObject.transform.position.x > map.GetComponent<Map_generator>().width)
        {

            Destroy(gameObject);
        }
    }
}
