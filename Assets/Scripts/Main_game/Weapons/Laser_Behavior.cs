using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Behavior : MonoBehaviour
{
    public float speed = 5;

    float boundary_Y;
    float boundary_X;
    void Start()
    {
        GameObject control = GameObject.Find("GameController");
        boundary_X = control.GetComponent<MiniGame_Controll>().boundarySize_X;
        boundary_Y = control.GetComponent<MiniGame_Controll>().boundarySize_Y;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Destroy();
    }

    private void Destroy()
    {
        if (transform.position.y >= boundary_Y)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(transform.gameObject);
            }
        }
    }

    private void Shoot()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        
    }
}
