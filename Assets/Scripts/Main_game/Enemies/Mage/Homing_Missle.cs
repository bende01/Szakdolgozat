using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Missle : MonoBehaviour
{
    private Transform player;

    public float speed = 8f;
    public float rotateSpeed = 20f;
    public float damage = 30;

    public Rigidbody2D rb;

    void Start()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player").transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

       
       
        Vector2 direction =  (Vector2)player.position -  rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "Enemy" && this.tag == "Player")
        {
            collision.GetComponent<SimpleEnemy>().GetDamage(damage);
            Destroy(gameObject);
        }


        if (collision.tag == "Player" && this.tag == "FireBall")
        {
            collision.GetComponent<Player>().GetDamage(damage);
            Destroy(gameObject);
        }



    }

}
