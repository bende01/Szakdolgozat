using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosting : MonoBehaviour
{
    public float ghostDelay;
    public GameObject ghost;

    private float currentTime=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= ghostDelay)
        {
            GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
            Destroy(currentGhost, 0.3f);
            currentTime = 0;
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }
}
