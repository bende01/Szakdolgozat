using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Enemy_Behavior : MonoBehaviour
{
    private GameObject player;
    public int attackRange = 8;
    public float cooldown = 0.5f;
    public float dashSpeed;
    public float dashBackslash;
    public float knockbackForce;
    public float damage;
    public GameObject warning;
    public GameObject graphics;
    public float warningTime = 0.5f;

    private Rigidbody2D rb;
    private bool onCooldown = false;
    private float cooling = 0;
    private float detectedPosition;


    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (onCooldown)
        {
            AutoStopDash();
            CooldownTimer();
        }

        Dash();

        FacePlayer();
    }

    private void Dash()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) <= attackRange && Mathf.Floor(transform.position.y) == Mathf.Floor(player.transform.position.y) && !onCooldown) //in line and in attack range
        {
            warning.SetActive(true);
            graphics.GetComponent<Ghosting>().enabled = true;

            Invoke("DoDash",warningTime);

            onCooldown = true;
           

        }

    }

    private void DoDash()
    {
        detectedPosition = player.transform.position.x;
        rb.AddForce(new Vector2(Mathf.Clamp(-(transform.position.x - player.transform.position.x), -1, 1) * dashSpeed, 0), ForceMode2D.Impulse);
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

    private void AutoStopDash()  //Stops Dash at the desired destination
    {
        if (rb.velocity.x > 0 && detectedPosition + dashBackslash <= transform.position.x)
        {
            rb.velocity = Vector2.zero;
        }

        if (rb.velocity.x < 0 && detectedPosition - dashBackslash >= transform.position.x)
        {
            rb.velocity = Vector2.zero;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().GetDamage(damage);
            collision.GetComponent<PlayerMovement>().Knockback(knockbackForce, Mathf.Clamp(rb.velocity.x, -1, 1));
            rb.velocity = Vector2.zero;
        }
    }



}
