using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Melee_enemy : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public LayerMask palyerLayer;
    public GameObject warning;
    public Transform sight;
    public LayerMask filter;
   

    public Transform detecter;
    

    public float patrolSpeed = 10;
    public float detectRange = 10;
    public float faceHug = 1;
    public float cooldown=2;
    public float warningTime = 0.5f;

    private GameObject player;
    

    private float cooling = 0;
    private bool onCooldown = false;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        

        if (onCooldown)
        {
            anim.SetBool("patrol", false);
            CooldownTimer();
        }
        else
        {
            if ( PlayerInSight())
            {
                onCooldown = true;
                Shunpo();
                warning.SetActive(true);
                
                Invoke("Attack", warningTime);
                
            }
            else
            {
                gameObject.GetComponent<TrailRenderer>().enabled = false;
                transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
                anim.SetBool("patrol", true);
                Patrol();
            }
        }

        

    }

    public void Attack()
    {
        anim.SetTrigger("attack");
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

    private void Shunpo() //teleport
    {
        gameObject.GetComponent<TrailRenderer>().enabled = (true);
        if (player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position = player.transform.position;
            transform.Translate(Vector3.left * faceHug);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = player.transform.position;
            transform.Translate(Vector3.left * faceHug);
        }
    }
  

    private void Patrol()
    {
        RaycastHit2D detect = Physics2D.Raycast(detecter.position, Vector2.down,1);

        if (detect.collider == null  )
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }

        RaycastHit2D detectSide = Physics2D.Raycast(detecter.position, Vector2.right, 1);

        if (detectSide.collider != null && detectSide.collider.tag == "Map")
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

   

    


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.Raycast(sight.position, player.transform.position-sight.position,detectRange,filter);
        Debug.DrawRay(sight.position, (player.transform.position - sight.position).normalized*detectRange, Color.red);
        if (hit.collider != null) { Debug.Log("hit: "+hit.collider.tag); }
        
        if (hit.collider !=null && hit.collider.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void OnDrawGizmos()
    {
        if(player!=null){ Gizmos.DrawLine(sight.position, player.transform.position); }
    }

    private void OnEnable()
    {
        onCooldown = false;
    }
}
