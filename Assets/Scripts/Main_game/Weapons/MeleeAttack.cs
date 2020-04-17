using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float damage = 50f;
    public Animator animator;
    public Transform attackPointMelee;
    public float attackRange = 2f;
    public LayerMask enemy;
    public float attackSpeed = 2f;

    float _cd = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)&&Time.time>_cd)
        {
            _cd = Time.time + attackSpeed;
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("attackMelee");
        Collider2D[] hitplayers = Physics2D.OverlapCircleAll(attackPointMelee.position, attackRange, enemy);

        foreach (Collider2D playerhit in hitplayers)
        {
            if (playerhit.tag == "Enemy")
                playerhit.GetComponent<SimpleEnemy>().GetDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPointMelee.position, attackRange);
    }
}
