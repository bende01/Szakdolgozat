using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    public Transform firePoint;
    public float damage =10;
    public LineRenderer line;

    bool canShoot = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)&&canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hit =Physics2D.Raycast(firePoint.position, firePoint.right);

        if(hit.collider != null && hit.collider.tag == "Enemy")
        {
            hit.collider.GetComponent<SimpleEnemy>().GetDamage(damage);

            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, hit.point);

        }else if (hit.collider.CompareTag("Map"))
        {
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, hit.point);
        }else
        {
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        line.enabled = true;

        yield return new WaitForSeconds(0.02f);

        line.enabled = false;

    }
    public void CanShoot(bool can)
    {
        canShoot = !can;
    }
}
