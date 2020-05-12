using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    Quaternion rot;
    void Start()
    {
        rot = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = rot;
    }
}
