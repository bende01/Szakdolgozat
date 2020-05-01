using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform startPoint;
    public GameObject bolt;
    // Update is called once per frame
    public void ShootEvent()
    {

        Debug.Log("made bolt");
        var shoot = Instantiate(bolt, startPoint.position,startPoint.rotation);

    }
}
