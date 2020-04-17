using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehavior : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask player;
    public float damage = 50f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.tag == "Player")
        {
            Attack();
        }
    }



    void Attack()
    {
        animator.SetTrigger("attack");
        Collider2D[] hitplayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player);

        foreach (Collider2D playerhit in hitplayers)
        {
            if (playerhit.tag=="Player")
                playerhit.GetComponent<Player>().GetDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
