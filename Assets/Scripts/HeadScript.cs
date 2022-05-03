using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    public GameObject MySkull;
    public GameObject MyJaw;

    void Update()
    {
        MyJaw.transform.localEulerAngles = Vector3.forward * (-10 + 10 * Mathf.Cos(Time.time));
    }
}
