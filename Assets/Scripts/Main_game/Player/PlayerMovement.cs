using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator player_animator;
    public float movementSpeed = 5f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    Rigidbody2D rb;
    PlayerControls control;

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

    }

    private void Moving()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed; // A -1  D 1 get which direction we are moving

        control.PlayerMoment.Move.performed += ctx => horizontalMove = ctx.ReadValue<float>();  //controller

        player_animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        

        if (Input.GetButtonDown("Jump") || control.PlayerMoment.Jump.ReadValue<float>()>0 )
        {
            jump = true;
            player_animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
        }
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

}