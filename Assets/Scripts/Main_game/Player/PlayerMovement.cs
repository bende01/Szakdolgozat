using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator player_animator;
    public float movementSpeed = 5f;
    public float dodgeDistance = 2f;
    public float dodgeCd = 2f;

    float cd=0;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    bool dodgeOnCd=false;
    Rigidbody2D rb;
    public PlayerControls control;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        control = new PlayerControls();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();

        if (dodgeOnCd)
        {
            cd += Time.deltaTime;

            if (cd > dodgeCd)
            {
                dodgeOnCd = false;
            }
        }

    }

    private void Moving()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed; // A -1  D 1 get which direction we are moving

        control.PlayerMoment.Move.performed += ctx => horizontalMove = ctx.ReadValue<float>();  //controller

        player_animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (Input.GetKeyDown(KeyCode.Space) || control.PlayerMoment.Jump.triggered)
        {
            jump = true;
            player_animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.S) || control.PlayerMoment.Crouch.ReadValue<float>() > 0.6f)
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.S) || control.PlayerMoment.Crouch.ReadValue<float>() < 0.5 && control.PlayerMoment.Crouch.ReadValue<float>() !=0)
        {
            crouch = false;
        }

        if ((Input.GetKeyDown(KeyCode.E) || control.PlayerMoment.Dodge.ReadValue<float>() > 0) && !dodgeOnCd)
        {
            Dodge();
            dodgeOnCd = true;
            cd = 0;
        }



    }

    private void Dodge()
    {
        gameObject.GetComponent<Ghosting>().enabled = true;
        gameObject.GetComponent<Player>().invulnerable = true;
        rb.AddForce(transform.right * dodgeDistance,ForceMode2D.Impulse);
        Invoke("DisableGhosting", 0.27f);
    }

    private void FixedUpdate() //for physics system
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);  //tell the controller what are we doing // * to move constantly, indenpendent from method call frequency
        jump = false;
    }

    public void OnLanding()
    {
        player_animator.SetBool("isJumping", false);
    }

    public void Crouching(bool isCrouching)
    {
        player_animator.SetBool("isCrouching", isCrouching);
        
    }

    public void Knockback(float force, float direction)
    {
        rb.AddForce(new Vector2(force * direction, 0), ForceMode2D.Impulse);
    }
    private void OnEnable()
    {
        control.PlayerMoment.Enable();
    }

    private void DisableGhosting()
    {
        gameObject.GetComponent<Player>().invulnerable = false;
        gameObject.GetComponent<Ghosting>().enabled = false;

    }

}