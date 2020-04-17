using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Behavior : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;


    bool attack = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
           
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.tag == "Player")
        {
            InvokeRepeating("Shoot", 0f, 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CancelInvoke("Shoot");
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
