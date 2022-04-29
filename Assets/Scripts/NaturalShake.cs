using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalShake : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = transform.forward * Mathf.Sin(Time.time * 3.1415f);
    }
}
