using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float attackSpeed = 3;
    public float attackDamage = 50.0f;


    float boundary_Y;
    float boundary_X;
    // Start is called before the first frame update
    void Start()
    {
        GameObject control = GameObject.Find("GameControllerr");
        boundary_X = control.GetComponent<MiniGame_Controll>().boundarySize_X;
        boundary_Y = control.GetComponent<MiniGame_Controll>().boundarySize_Y;

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
            other.gameObject.GetComponent<Mini_Player>().CollectedTripleOrb();
            Destroy(this.gameObject);
        }


        

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
