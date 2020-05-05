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
    
    private Tilemap map;

    public float patrolDirectionTime= 2f;
    public float patrolSpeed = 10;
    public float detectRange = 10;
    public float faceHug = 1;
    public float cooldown=2;

    private GameObject player;
    

    private float cooling = 0;
    private bool onCooldown = false;
    private void Awake()
    {
        player = GameObject.Find("Player");
        map = GameObject.Find("Tilemap").GetComponent<Tilemap>();
    }

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //patrol
        

        if (onCooldown)
        {
            anim.SetBool("patrol", false);
            CooldownTimer();
        }
        else
        {
            if (PlayerDetected() && PlayerInSight())
            {
                Shunpo();
                warning.SetActive(true);
                Invoke("Attack", 0.75f);
                onCooldown = true;
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

   

    private Vector3Int ClampPosition()
    {
        return new Vector3Int(Mathf.FloorToInt (transform.position.x), Mathf.FloorToInt(transform.position.y), Mathf.FloorToInt(transform.position.z));
    }

    private bool PlayerDetected()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, detectRange, palyerLayer);

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.Raycast(sight.position, player.transform.position-sight.position,filter);
        Debug.DrawRay(sight.position, player.transform.position - sight.position, Color.red);
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
        Gizmos.DrawLine(sight.position, player.transform.position);
    }

}
