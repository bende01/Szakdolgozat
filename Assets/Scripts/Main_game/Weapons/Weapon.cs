using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float cooldown= 6f;

    private float cooling=0;
    private bool onCooldown = false;
    private PlayerControls controller;

    private void Start()
    {
        controller = gameObject.GetComponent<PlayerMovement>().control;
    }
    void Update()
    {
        CooldownTimer();

        if ((Input.GetKeyDown(KeyCode.C) || controller.PlayerMoment.Shoot.ReadValue<float>() > 0 )&& !onCooldown)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        onCooldown = true;
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }

    private void CooldownTimer()
    {
        cooling += Time.deltaTime;

        if (cooling >= cooldown)
        {

            onCooldown = false;
            cooling = 0;



        }
    }

}
