using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float cooldown= 6f;

    private float cooling=0;
    private bool onCooldown = false;
    private PlayerControls controller;
    public Image cooldownImage;

    private void Start()
    {
        controller = gameObject.GetComponent<PlayerMovement>().control;
        cooling = cooldown;
        
    }
    void Update()
    {
        if (onCooldown) 
        { 
            CooldownTimer();
        }

        cooldownImage.fillAmount = cooling / cooldown;

        if ((Input.GetKeyDown(KeyCode.K) || controller.PlayerMoment.Shoot.ReadValue<float>() > 0 )&& !onCooldown)
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        onCooldown = true;
        cooling = 0;
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }

    private void CooldownTimer()
    {
        cooling += Time.deltaTime;

        if (cooling >= cooldown)
        {

            onCooldown = false;



        }
    }

}
