using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Enemy : MonoBehaviour
{
    public float attackSpeed = 3;
    public float attackDamage = 50.0f;

    private Animator animator;
    

    float boundary_Y;
    float boundary_X;
    // Start is called before the first frame update
    void Start()
    {
        GameObject control = GameObject.Find("GameControllerr");

        boundary_X = control.GetComponent<MiniGame_Controll>().boundarySize_X;
        boundary_Y = control.GetComponent<MiniGame_Controll>().boundarySize_Y;

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       

        FallDown();



        Destroy();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            attackSpeed = 0;
            other.gameObject.GetComponent<Mini_Player>().Damaged(attackDamage);
            Destroy(this.gameObject,2f);
        }


        if(other.tag == "Laser")
        {
            attackSpeed = 0;
            Destroy(this.gameObject,2f);
            Destroy(other.gameObject);
            
        }
        animator.SetTrigger("New Trigger");
    }

    private void FallDown()
    {
        transform.Translate(Vector3.down * attackSpeed * Time.deltaTime);
    }

    private void Destroy()
    {
        if (transform.position.y <= -boundary_Y)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
