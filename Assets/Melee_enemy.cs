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
    
    private Tilemap map;

    public float patrolDirectionTime= 2f;
    public float patrolSpeed = 10;
    public float detectRange = 10;
    public float faceHug = 1;

    private GameObject player;
    private float time=0;
    private bool goingRight = true;
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

        rb.velocity = transform.right * patrolSpeed;
        time += Time.deltaTime;

        if (PlayerDetected())
        {
            Shunpo();
        }
        else { Patrol(); }

    }

    private void Shunpo() //teleport
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.position = player.transform.position;
            transform.Translate(Vector3.right * faceHug);
        }
        else
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            transform.position = player.transform.position;
            transform.Translate(Vector3.left * faceHug);
        }
    }
  

    private void Patrol()
    {
        if (!map.HasTile(ClampPosition() + Vector3Int.right + Vector3Int.down * 2- Vector3Int.up * (int)map.CellToWorld(Vector3Int.zero).y) && goingRight)
        {
            
            patrolSpeed = -patrolSpeed;
            goingRight = false;

            Debug.Log("Jobb: "+ (ClampPosition() + Vector3Int.right + Vector3Int.down * 2 - Vector3Int.up * (int)map.CellToWorld(Vector3Int.zero).y));


        }
        else if (!map.HasTile(ClampPosition() + Vector3Int.left + Vector3Int.down * 2 - Vector3Int.up * (int)map.CellToWorld(Vector3Int.zero).y) && !goingRight)
        {
            patrolSpeed = -patrolSpeed;
            goingRight = true;
            Debug.Log("Bal: " + (ClampPosition() + Vector3Int.left + Vector3Int.down * 2 - Vector3Int.up * (int)map.CellToWorld(Vector3Int.zero).y));

        }

        if (time >= patrolDirectionTime)
        {
            patrolSpeed = -patrolSpeed;
            time = 0;


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


  
}
