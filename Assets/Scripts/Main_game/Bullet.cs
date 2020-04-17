using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 20;

    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<SimpleEnemy>().GetDamage(damage);
            Destroy(gameObject);
        }


        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().GetDamage(damage);
            Destroy(gameObject);
        }

    }

}
