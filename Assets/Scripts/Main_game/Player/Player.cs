using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100;

    public string[] weapons;

    

    int i = 0;

    private void Update()
    {
        CicleWeapons();

        Die();
    }

    private void CicleWeapons()
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            if (i + 1 < weapons.Length)
            {
                i++;
                SwitchWeapon(weapons[i]);
            }
            else
            {
                i = 0;
                SwitchWeapon(weapons[i]);
            }
        }
    }

    private void SwitchWeapon(string wep)
    {
        switch (wep)
        {
            case "Bullet":
                GetComponent<Weapon>().enabled = true;
                GetComponent<LaserWeapon>().enabled = false;
                break;
            case "Laser":
                GetComponent<LaserWeapon>().enabled = true;
                GetComponent<Weapon>().enabled = false;
                break;
        }
    }

    private void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void InstantDeath()
    {
        Destroy(gameObject);
    }




    public void GetDamage(float dmg)
    {
        health -= dmg;
    }
}
