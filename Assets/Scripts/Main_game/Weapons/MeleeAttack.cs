using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float damage = 50f;
    public Animator animator;
    public Transform attackPointMelee;
    public float attackSpeed = 2f;

    PlayerControls controller;
    float _cd = 0;

    private void Start()
    {
        controller = animator.GetComponent<PlayerMovement>().control;
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.L) || controller.PlayerMoment.Attack.ReadValue<float>() > 0 )&& Time.time>_cd)
        {
            _cd = Time.time + attackSpeed;
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("attackMelee");

       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") { collision.GetComponent<SimpleEnemy>().GetDamage(damage); }

        if (collision.tag == "FireBall") { Destroy(collision.gameObject); }

    }
}
