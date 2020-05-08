using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpy_Jump : MonoBehaviour
{
    public Rigidbody2D jumpy;
    public float jumpSpeed;
    public GameObject attack;
    
    public void Jump()
    {
        jumpy.AddForce(Vector2.right * jumpSpeed);
    }

    private void Stop()
    {
        jumpy.velocity = Vector2.zero;
    }

    public void SwitchToOne()
    {
        attack.GetComponent<jumpy_damage>().sequence = 1;
    }
    public void SwitchToTwo()
    {
        attack.GetComponent<jumpy_damage>().sequence = 2;
    }
    public void SwitchToThree()
    {
        attack.GetComponent<jumpy_damage>().sequence = 3;
    }

}
