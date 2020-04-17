using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    bool canShoot = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)&&canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }

    public void CanShoot(bool can)
    {
        canShoot = !can;
    }

}
