using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowman_Behavior : MonoBehaviour
{
    public float attackRange = 10f;
    public float meleeRange = 1f;
    public float cooldown = 1.5f;
    public Animator anim;
    public GameObject warning;

    private GameObject player;
    private bool onCooldown=true;
    private float cooling = 0;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();

        if (onCooldown)
        {
            CooldownTimer();
        }
       
        if (PlayerDetected()  && !onCooldown)
        {
            warning.SetActive(true);
            Invoke("DoShoot",0.5f);
            onCooldown = true;
        }


    }

    private void DoShoot()
    {
        anim.SetTrigger("Shoot");
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
        if (Mathf.Abs(transform.position.x - player.transform.position.x) <= attackRange && Mathf.Floor(transform.position.y) == Mathf.Floor(player.transform.position.y)){
            return true;
        } else { return false; }
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
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackRange,transform.position.y,transform.position.z));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - attackRange, transform.position.y, transform.position.z));

        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + meleeRange, transform.position.y, transform.position.z));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - meleeRange, transform.position.y, transform.position.z));
    }

}
