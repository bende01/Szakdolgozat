using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_behaviour : MonoBehaviour
{
    public float attackRange = 10f;
    public float meleeRange = 1f;
    public float cooldown = 1.5f;
    public Animator anim;
    public GameObject warning;
    public float detectRange= 10f;
    public GameObject fireBall;

    public LayerMask playerLayer;

    public Transform firePoint;

    private GameObject player;
    private bool onCooldown = true;
    private float cooling = 0;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }

 

    void Update()
    {

        if (onCooldown)
        {
            CooldownTimer();
        }

        if (PlayerDetected())
        {
            FacePlayer();
            if (!onCooldown) 
            {
                warning.SetActive(true);
                Invoke("DoShoot", 0.5f);
                onCooldown = true;
            }
                
           
        }


    }

    private void DoShoot()
    {
        anim.SetTrigger("Shoot");
        Instantiate(fireBall, firePoint.position,firePoint.rotation);
        warning.SetActive(false);
    }

    private void CooldownTimer()
    {
        cooling += Time.deltaTime;

        if (cooling >= cooldown)
        {

            onCooldown = false;
            cooling = 0;



        }
    }
    private bool PlayerDetected()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, detectRange, playerLayer);

        foreach (var playerHit in hitPlayer)
        {
            if (playerHit.tag == "Player")
            {
                //anim attack
                return true;
            }
        }
        return false;

    }

    private void FacePlayer()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }

    private void OnDrawGizmosSelected() //check AttackRange
    {
        Gizmos.DrawWireSphere(firePoint.transform.position, detectRange);
    }
}
