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
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moving();

    }

    private void Moving()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;

        player_animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
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

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
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
}
